using EDVirtualCOM2TCP;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

            Hub4Com.OpenPorts();
        }
        
        protected override void OnStop()
        {
            EDDebug.Log("Service OnStop");

            Hub4Com.ClosePorts();

            Com0Com.RemoveAll();
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
    }
}
