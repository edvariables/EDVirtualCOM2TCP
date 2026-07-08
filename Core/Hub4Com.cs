using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace EDVirtualCOM2TCP
{
    public static class Hub4Com
    {
        private static Thread _openPorts_thread;
        public static string ExeFileName
        {
            get
            {
                string fileName = Path.Combine(Environment.ExpandEnvironmentVariables(Settings.Hub4Com_path), "hub4com.exe");
                if (!File.Exists(fileName))
                {
                    fileName = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, fileName);
                    if (!File.Exists(fileName))
                    {
                        fileName = Path.Combine(Environment.ExpandEnvironmentVariables(Settings.Hub4Com_path), "hub4com.exe");
                        fileName = Path.Combine(Environment.ExpandEnvironmentVariables(Settings.Com0Com_path), fileName);
                        if (!File.Exists(fileName))
                            throw new Exception("Fichier Hub4Com introuvable : " + fileName);
                    }
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
                EDDebug.Log("SUCCES OpenPorts");
                Thread.Sleep(300);
            }
            else
                EDDebug.Log("ECHEC OpenPorts");
            return thread;
        }

        public static bool OpenPorts(ICommandFile.ProcessExited processExited = null)
        {
            int cncNum = Com0Com.CreatedPair_CNC;
            if (cncNum < 0)
                cncNum = Com0Com.BusyNames().Length - 1;
            if (cncNum < 0)
                throw new Exception("Aucun port disponible pour Hub4Com.OpenPorts.");
            string options = Settings.Hub4Com_options;
            string cmd = options
                    + " \"\\\\.\\CNCB" + cncNum.ToString() + "\""
                    + " --use-driver=tcp \"*" + Settings.IP_Address + ":" + Settings.IP_Port
                    + "\"";

            _openPorts_thread = RunAsThread(cmd, processExited);
            return _openPorts_thread != null;
        }

        public static bool IsProcessRunning
        {
            get {
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
                ICommandFile.StopThread( _openPorts_thread );
                Thread.Sleep(300);
            }
            catch(Exception ex)
            {
                EDDebug.Log("ClosePorts : " + (ex.InnerException==null ? ex.Message : ex.InnerException.Message));
            }
            finally
            {
                _openPorts_thread = null;
            }
        }
    }
}
