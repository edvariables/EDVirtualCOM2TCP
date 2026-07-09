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

        public Bridge(string cnc, string tcp) { 
            if( ! this.Check_Settings(cnc, tcp))
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
            TCP_port = TCP.Length>1 ? int.Parse(TCP[1]) : 0;

            Console.WriteLine("Appli <=> {0} <=> {1} <=> {2}:{3} <=> Tcp device", COM, CNC, TCP_address, TCP_port);
            EDDebug.Log("Appli <=> {0} <=> {1} <=> {2}:{3} <=> Tcp device", COM, CNC, TCP_address, TCP_port);

            return true;
        }

        public void Start()
        {
            //SerialPort com=new SerialPort();
            SerialPort cnc=new SerialPort();
            TcpClient tcpClient = new TcpClient();

            //com.PortName = COM;
            cnc.PortName = CNC;

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

                int retry_delay = 5;
                Console.WriteLine("Echec de connexion TCP. Nouvelle tentative dans {0} s...", retry_delay);
                EDDebug.Log("Echec de connexion TCP.Nouvelle tentative dans {0} s...", retry_delay);
                Thread.Sleep(1000 * retry_delay);
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

                int retry_delay = 15;
                Console.WriteLine("Echec de connexion {0}. Nouvelle tentative dans {1} s...", cnc.PortName, retry_delay);
                EDDebug.Log("Echec de connexion {0}. Nouvelle tentative dans {1} s...", cnc.PortName, retry_delay);
                Thread.Sleep(1000 * retry_delay);
                return;
            }

            try
            {
                NetworkStream tcpStream = tcpClient.GetStream();

                //BinaryReader BRclient = new BinaryReader(tcpStream);

                // TCP => COM
                new Task(() =>
                {
                    try
                    {
                        int nMaxBytes = tcpClient.ReceiveBufferSize;
                        Byte[] bytes = new byte[nMaxBytes];

                        while (TunnelAlive)
                        {
                            int nBytes = 0;
                            while (tcpStream.DataAvailable
                            && (nBytes < nMaxBytes))
                            {
                                bytes[nBytes] = ((byte)tcpStream.ReadByte());
                                nBytes++;
                            }
                            if (nBytes > 0)
                            {
                                cnc.Write(bytes, 0, nBytes);

                                if (Settings.LogEnabled)
                                {
                                    string msg = Encoding.ASCII.GetString(bytes,0, nBytes); //the message incoming
                                    Console.WriteLine("{0} > {1}", "TCP", msg);
                                    EDDebug.Log("{0} > {1}", "TCP", msg);
                                }
                            }
                            else
                                Thread.Sleep(100);//TODO
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(" TCP error: {0}. Closing.", ex.Message.ToString());
                        EDDebug.Log(" TCP error: {0}. Closing.", ex.Message.ToString()); 
                        TunnelAlive = false;
                    }
                }).Start();


                // COM => TCP
                BinaryWriter BWclient = new BinaryWriter(tcpStream);
                Byte[] cncBytes = new byte[cnc.ReadBufferSize];
                cnc.DataReceived += (sender, e) =>
                {
                    try
                    {
                        int nBytes = cnc.BytesToRead;
                        cnc.Read(cncBytes, 0, nBytes);
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
            // Wait while connecion is alive
            while (TunnelAlive)
            {
                TunnelAlive = tcpClient != null && tcpClient.Connected;
                if( ! TunnelAlive)
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
            if(tcpClient != null)
                try
                {
                    tcpClient.Close();
                }
                finally { tcpClient = null; }
            if( cnc != null)
                try
                {
                    cnc.Close();
                }
                finally { cnc = null; }
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
