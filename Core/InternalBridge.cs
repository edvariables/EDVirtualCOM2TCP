using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDVirtualCOM2TCP
{
    public static class InternalBridge
    {
        private static Thread _openPorts_thread;
        public static string ExeFileName
        {
            get
            {
                string fileName = "EDVirtualCOM2TCP.InternalBridge.exe";
                fileName = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, fileName);
                if (!File.Exists(fileName))
                {
                    throw new Exception("Fichier Hub4Com introuvable : " + fileName);
                }
                return fileName;
            }
        }

        public static string Run(string parameters)
        {
            return ICommandFile.Run(ExeFileName, parameters);
        }
        public static Thread RunAsThread(string parameters, ICommandFile.ProcessExited processExited = null)
        {
            Thread thread = ICommandFile.RunAsThread(ExeFileName, parameters, processExited);
            if (thread != null)
            {
                EDDebug.Log("SUCCES InternalBridge.OpenPorts");
                Thread.Sleep(300);
            }
            else
                EDDebug.Log("ECHEC InternalBridge.OpenPorts");
            return thread;
        }

        public static bool OpenPorts(ICommandFile.ProcessExited processExited = null)
        {
            int com = Com0Com.CreatedPair_COMNum;
            if (com <= 0)
                com = Com0Com.AvailableCOM() - 2;
            int cncNum = com + 1;

            string cmd = "CNC=COM" + cncNum.ToString()
                    + " TCP=" + Settings.IP_Address + ":" + Settings.IP_Port;

            _openPorts_thread = RunAsThread(cmd, processExited);
            return _openPorts_thread != null;
        }

        public static bool IsProcessRunning
        {
            get
            {
                return ICommandFile.IsProcessRunning(_openPorts_thread);
            }
        }

        public static void ClosePorts()
        {
            if (_openPorts_thread == null)
            {
                EDDebug.Log("ClosePorts == null");
                return;
            }
            try
            {
                EDDebug.Log("ClosePorts ICommandFile.StopThread");
                ICommandFile.StopThread(_openPorts_thread);
                Thread.Sleep(300);
            }
            catch (Exception ex)
            {
                EDDebug.Log("ClosePorts : " + (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
            }
            finally
            {
                _openPorts_thread = null;
            }
        }
    }
}
