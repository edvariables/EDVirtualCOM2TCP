using EDVirtualCOM2TCP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static EDVirtualCOM2TCP.ICommandFile;

namespace EDVirtualCOM2TCP
{
    public partial class EDVirtualCOM2TCP_Service : ServiceBase
    {
        public EDVirtualCOM2TCP_Service()
        {
            InitializeComponent();
            EDDebug.CheckFile();
        }

        protected override void OnStart(string[] args)
        {
            EDDebug.Log("Service OnStart");
            if (!Check_settings())
            {
                EDDebug.Log(Settings.IP_Address + ':' + Settings.IP_Port);

                throw new Exception("Le paramétrage est incomplet");
            }

            Com0Com.RemoveAll();

            Com0Com.CreatePair();

            Thread.Sleep(1000  * Settings.Service_Delay);

            Hub4Com.OpenPorts( OnHub4ComProcessExited );
        }
        
        protected override void OnStop()
        {
            EDDebug.Log("Service OnStop");

            Hub4Com.ClosePorts();

            EDDebug.Log("Service Stop Closed Ports");

            Com0Com.RemoveAll();

            EDDebug.Log("Service Stop Removed All");

            EDDebug.Log("Service Stopped...");
        }

        private bool Check_settings()
        {
            if ( ! Check_com0com())
                return false;

            if ( ! Check_IP())
                return false;

            EDDebug.Log("Check_settings : OK");
            return true;
        }
        private bool Check_com0com()
        {
            if (Com0Com.IsInstalled)
                return true;

            EDDebug.Log("Service : Com0Com is NOT installed");
            return false;
        }
        private bool Check_IP()
        {
            if (Settings.IP_Address == "")
                return false;
            if (Settings.IP_Port == 0)
                return false;
            return true;
        }

        protected void OnHub4ComProcessExited()
        {
            EDDebug.Log("Service OnHub4ComProcessExited");

            Com0Com.RemoveAll();

            EDDebug.Log("Service Stop after Closed Ports");
            ServiceManager.Stop();
            //this.Stop();
            EDDebug.Log("Service should be Stopped");
            //Thread thread=new Thread(this.Stop);
            //thread.Start(); 
        }
    }
}
