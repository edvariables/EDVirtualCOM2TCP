using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDVirtualCOM2TCP
{
    internal class Bridge : IDisposable
    {
        string CNC, TCP_address;
        int TCP_port;

        Thread _runningThread;

        public Bridge(string cnc, string tcp)
        {
            if (!this.Check_Settings(cnc, tcp))
            {
                return;
            }
        }
        bool Check_Settings(string cnc, string tcp)
        {
            CNC = cnc;
            string COM = "COM" + (int.Parse(cnc.Substring(3)) - 1).ToString();

            string[] TCP = tcp.Split(':');
            TCP_address = TCP[0];
            TCP_port = TCP.Length > 1 ? int.Parse(TCP[1]) : 0;

            TCP_Reconnect_Delay = Settings.TCP_Reconnect_Delay;
            COM_Reconnect_Delay = Settings.COM_Reconnect_Delay;
            TCP_Check_Send = Settings.TCP_Check_Send_Enabled ? Settings.TCP_Check_Send : "";
            TCP_Check_Timeout = Settings.TCP_Check_Timeout;
            TCP_Connnect_OnCOM = Settings.TCP_Connnect_OnCOM;
            TCP_Disconnect_Delay = Settings.TCP_Disconnect_Delay;

            Console.WriteLine("Appli <=> {0} <=> {1} <=> {2}:{3} <=> Tcp device", COM, CNC, TCP_address, TCP_port);
            EDDebug.Log("Appli <=> {0} <=> {1} <=> {2}:{3} <=> Tcp device", COM, CNC, TCP_address, TCP_port);

            return true;
        }

        int TCP_Reconnect_Delay = 5;
        int COM_Reconnect_Delay = 10;
        string TCP_Check_Send = "";
        int TCP_Check_Timeout = 3000;
        bool TCP_Connnect_OnCOM = true;
        bool TCP_Waiting_COM = false;
        int TCP_Disconnect_Delay = 30000;
        long TCP_Received_LastTicks = 0L;

        public void Start()
        {
            //SerialPort com=new SerialPort();
            SerialPort cnc = new SerialPort();
            TcpClient tcpClient = new TcpClient();

            //com.PortName = COM;
            cnc.PortName = CNC;

            bool TCP_Waiting_Demand = false;

            bool TunnelAlive = true;
            try
            {
                tcpClient.Connect(TCP_address, TCP_port);
                Console.WriteLine("Connexion OK avec {0}:{1}", TCP_address, TCP_port);
                EDDebug.Log("Connexion OK avec {0}:{1}", TCP_address, TCP_port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());

                Console.WriteLine("Echec de connexion TCP. Nouvelle tentative dans {0} s...", TCP_Reconnect_Delay);
                EDDebug.Log("Echec de connexion TCP.Nouvelle tentative dans {0} s...", TCP_Reconnect_Delay);
                Thread.Sleep(1000 * TCP_Reconnect_Delay);
                return;
            }

            try
            {
                cnc.Open();
                Console.WriteLine("Connexion OK avec {0}", cnc.PortName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());

                Console.WriteLine("Echec de connexion {0}. Nouvelle tentative dans {1} s...", cnc.PortName, COM_Reconnect_Delay);
                EDDebug.Log("Echec de connexion {0}. Nouvelle tentative dans {1} s...", cnc.PortName, COM_Reconnect_Delay);
                Thread.Sleep(1000 * COM_Reconnect_Delay);
                return;
            }

            try
            {
                NetworkStream tcpStream = tcpClient.GetStream();
                BinaryWriter BWclient = new BinaryWriter(tcpStream);

                //BinaryReader BRclient = new BinaryReader(tcpStream);

                // TCP => COM
                new Task(() =>
                {
                    try
                    {
                        int nMaxBytes = tcpClient.ReceiveBufferSize;
                        Byte[] bytes = new byte[nMaxBytes];

                        Check_Send(BWclient, TCP_Check_Send);

                        while (TunnelAlive)
                        {
                            if (!tcpClient.Connected)
                            {
                                if (TCP_Connnect_OnCOM)
                                    Thread.Sleep(100);//TODO
                                else
                                {
                                    TunnelAlive = false;
                                    break;
                                }
                                continue;
                            }

                            int nBytes = 0;
                            while (tcpStream.DataAvailable
                            && (nBytes < nMaxBytes))
                            {
                                bytes[nBytes] = ((byte)tcpStream.ReadByte());
                                nBytes++;
                            }
                            if (nBytes > 0)
                            {
                                if (_IsChecking_Send)
                                {
                                    string msg = Encoding.ASCII.GetString(bytes, 0, nBytes); //the message incoming
                                    Check_Send_Answer(BWclient, msg);
                                }
                                else
                                    cnc.Write(bytes, 0, nBytes);

                                Disconnect_Timeout_Reset();

                                if (Settings.LogEnabled)
                                {
                                    string msg = Encoding.ASCII.GetString(bytes, 0, nBytes); //the message incoming
                                    Console.WriteLine("{0} > {1}", "TCP", msg);
                                    EDDebug.Log("{0} > {1}", "TCP", msg);
                                }
                            }
                            else if (Check_Send_Timeout())
                            {
                                Console.WriteLine("TCP Timeout after check message");
                                EDDebug.Log("TCP Timeout after check message");
                                TunnelAlive = false;
                                break;
                            }
                            else if (Disconnect_Timeout())
                            {
                                Console.WriteLine("No communication needed : TCP disconnected");
                                EDDebug.Log("No communication needed : TCP disconnected");

                                try
                                {
                                    TCP_Waiting_Demand = true;

                                    BWclient.Close();
                                    BWclient = null;
                                    tcpStream.Close();
                                    tcpStream = null;
                                    tcpClient.Close();
                                }
                                finally { }

                            }
                            else
                                Thread.Sleep(100);//TODO
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(" TCP error: {0}. Closing.", ex.Message.ToString());
                        EDDebug.Log(" TCP error: {0}. Closing.", ex.Message.ToString());
                    }
                    finally
                    {
                        TunnelAlive = false;
                        TCP_Waiting_Demand = false;
                    }
                }).Start();


                // COM => TCP
                Byte[] cncBytes = new byte[cnc.ReadBufferSize];
                cnc.DataReceived += (sender, e) =>
                {
                    try
                    {
                        int nBytes = cnc.BytesToRead;
                        cnc.Read(cncBytes, 0, nBytes);

                        if (!tcpClient.Connected)
                        {
                            if (TCP_Waiting_Demand)
                            {
                                tcpClient = new TcpClient();
                                tcpClient.Connect(TCP_address, TCP_port);
                                tcpStream = tcpClient.GetStream();
                                BWclient = new BinaryWriter(tcpStream);

                                Console.WriteLine("TCP reconnected");
                                EDDebug.Log("TCP reconnected");
                                
                                Disconnect_Timeout_Reset();

                                TCP_Waiting_Demand = false;
                            }
                            else
                                throw new Exception("TCP not connected");
                        }
                        BWclient.Write(cncBytes, 0, nBytes);

                        if (Settings.LogEnabled)
                        {
                            string msg = Encoding.ASCII.GetString(cncBytes, 0, nBytes); //the message incoming
                            Console.WriteLine("{0} > {1}", "COM", msg);
                            EDDebug.Log("{0} > {1}", "COM", msg);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Write to TCP error: {0}. Closing.", ex.Message.ToString());
                        EDDebug.Log("Write to TCP error: {0}. Closing.", ex.Message.ToString());
                        TunnelAlive = false;
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Tunnel error: {0}. Closing.", ex.Message.ToString());
                TunnelAlive = false;
            }
            ;

            System.Threading.Thread.Sleep(1000);
            // Wait while connexion is alive
            while (TunnelAlive)
            {
                TunnelAlive = tcpClient != null && (tcpClient.Connected || TCP_Waiting_Demand);
                if (!TunnelAlive)
                {
                    int retry_delay = 5;
                    Console.WriteLine("Déconnexion TCP. Nouvelle tentative dans {0} s...", retry_delay);
                    EDDebug.Log("Déconnexion TCP. Nouvelle tentative dans {0} s...", retry_delay);
                    Thread.Sleep(1000 * retry_delay);
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }
            ;
            if (tcpClient != null)
                try
                {
                    tcpClient.Close();
                }
                finally { tcpClient = null; }
            if (cnc != null)
                try
                {
                    cnc.Close();
                }
                finally { cnc = null; }
        }

        /**
         * TCP_Check_Send
         * Check TCP communication sending a string and waiting for an answer
         * 
         * */
        bool _IsChecking_Send = false;
        long _IsChecking_Send_Start = 0L;
        void Check_Send(BinaryWriter BWclient, string check_msg)
        {
            if (String.IsNullOrEmpty(check_msg))
                return;

            _IsChecking_Send = true;
            _IsChecking_Send_Start = DateTime.Now.Ticks;

            check_msg = check_msg
                .Replace("<CRLF>", "\n\r").Replace("<crlf>", "\n\r")
                .Replace("<CR>", "\n").Replace("<cr>", "\n")
                .Replace("<LF>", "\r").Replace("<lf>", "\r")
                .Replace("<TAB>", "\t").Replace("<tab>", "\t");

            var bytes = Encoding.ASCII.GetBytes(check_msg);
            BWclient.Write(bytes, 0, bytes.Length);
        }

        void Check_Send_Answer(BinaryWriter BWclient, string msg)
        {
            _IsChecking_Send = false;
            Console.WriteLine("TCP answer to check message : {0}.", msg);
            EDDebug.Log("TCP answer to check message : {0}.", msg);
        }

        bool Check_Send_Timeout()
        {
            if (!_IsChecking_Send) return false;

            long delay = (DateTime.Now.Ticks - _IsChecking_Send_Start) / TimeSpan.TicksPerMillisecond;
            if (delay < TCP_Check_Timeout) return false;

            _IsChecking_Send = false;

            return true;
        }

        bool Disconnect_Timeout()
        {
            if (TCP_Received_LastTicks == 0L) return false;

            long delay = (DateTime.Now.Ticks - TCP_Received_LastTicks) / TimeSpan.TicksPerMillisecond;
            if (delay < TCP_Disconnect_Delay) return false;

            Disconnect_Timeout_Reset();

            return true;
        }
        void Disconnect_Timeout_Reset()
        {
            TCP_Received_LastTicks = DateTime.Now.Ticks;
        }


        public void Dispose()
        {
            if (_runningThread == null)
                return;
            try
            {
                _runningThread.Abort();
            }
            finally
            {
                _runningThread = null;
            }
        }
    }
}
