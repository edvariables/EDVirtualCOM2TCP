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

            if (Settings.Bridge_Hub4Com || Settings.Com0Com_CreateCOM)
            {
                Com0Com.RemoveAll();

                Com0Com.CreatePair();
            }

            if(Settings.Service_Delay > 0)
                Thread.Sleep(1000  * Settings.Service_Delay);

            if( Settings.Bridge_Hub4Com)
                Hub4Com.OpenPorts( OnBridgeProcessExited );
            else
                InternalBridge.OpenPorts(OnBridgeProcessExited);
        }
        
        protected override void OnStop()
        {
            EDDebug.Log("Service OnStop");

            if (Settings.Bridge_Hub4Com)
                Hub4Com.ClosePorts();
            else
                InternalBridge.ClosePorts();

            EDDebug.Log("Service Stop Closed Ports");

            if (Settings.Bridge_Hub4Com || Settings.Com0Com_CreateCOM)
            {
                Com0Com.RemoveAll();
            }

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

        protected void OnBridgeProcessExited()
        {
            EDDebug.Log("Service OnBridgeProcessExited");

            Com0Com.RemoveAll();

            EDDebug.Log("Service Stop after Closed Ports");
            ServiceManager.Stop();
            
            EDDebug.Log("Service should be Stopped");
        }
    }
}
