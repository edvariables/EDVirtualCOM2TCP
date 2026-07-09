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
    public class InternalBridge:ICommandFile
    {

        private static InternalBridge _instance;
        public static InternalBridge Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InternalBridge();
                return _instance;
            }
        }

        private Thread _openPorts_thread;
        public override string ExeFileName
        {
            get
            {
                string fileName = "EDVirtualCOM2TCP.InternalBridge.exe";
                fileName = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, fileName);
                if (!File.Exists(fileName))
                {
                    throw new Exception("Fichier EDVirtualCOM2TCP.InternalBridge.exe introuvable : " + fileName);
                }
                return fileName;
            }
        }

        public bool OpenPorts(ICommandFile.ProcessExited processExited = null)
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

        public void ClosePorts()
        {
            if (_openPorts_thread == null)
            {
                EDDebug.Log("ClosePorts == null");
                return;
            }
            try
            {
                EDDebug.Log("ClosePorts ICommandFile.StopThread");
                base.StopThread(_openPorts_thread);
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

        public override bool IsProcessRunning
        {
            get
            {
                return base.IsThreadProcessRunning(_openPorts_thread);
            }
        }
    }
}
