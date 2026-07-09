using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDVirtualCOM2TCP
{
    [RunInstaller(true)]
    public partial class AppInstaller : System.Configuration.Install.Installer
    {
        public AppInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            EDDebug.Log("AppInstaller : Install");
            base.Install(stateSaver);

            foreach (System.Collections.DictionaryEntry o in this.Context.Parameters)
            {
                EDDebug.LogLine("Context.Parameters : {0} = {1}", o.Key.ToString(), o.Value.ToString());
            }

            if (!Com0Com.IsInstalled)
            {
                if (MessageBox.Show("Le composant Com0Com n'est pas installé."
                    + "\nIl est indispensable pour générer des ports virtuels."
                    + "\nVoulez-vous le télécharger ?"
                    + "\n(Attention, la version 3.0 est incompatible avec Windows 11 mais la v2.2 suffit.)"
                    , "Installation de " + Settings.ServiceName
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Com0Com.Download();

                    MessageBox.Show("Quand l'installation de Com0Com sera effectuée, \ncliquez sur Ok pour poursuivre le démarrage."
                    , "Installation de " + Settings.ServiceName
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

                }
            }

            if (this.Context.Parameters.ContainsKey("install_service")
            && this.Context.Parameters["install_service"] == "INSTALL_SERVICE")
            {
                EDDebug.Log("Service Install : Delete");
                ServiceManager.Delete();

                EDDebug.Log("Service Install : Create");
                ServiceManager.Create();
            }
            if (this.Context.Parameters.ContainsKey("start_service")
            && this.Context.Parameters["start_service"] == "START_SERVICE")
            {
                EDDebug.Log("Service Install : " + ServiceManager.Status.ToString());
                ServiceManager.Start();
            }
        }

        public override void Commit(IDictionary savedState)
        {
            EDDebug.Log("AppInstaller : Commit");
            base.Commit(savedState);

            foreach (System.Collections.DictionaryEntry o in this.Context.Parameters)
            {
                EDDebug.LogLine("Context.Parameters : {0} = {1}", o.Key.ToString(), o.Value.ToString());
            }

            if (this.Context.Parameters.ContainsKey("start_app")
            && this.Context.Parameters["start_app"] == "START_APP")
            {
                Thread thread = new Thread(StartApp);
                thread.Start();
                Thread.Sleep(2000);
            }
        }

        private void StartApp()
        {
            EDDebug.Log("AppInstaller : StartApp");
            Process.Start(Assembly.GetExecutingAssembly().Location, "Post-install");
        }

        public override void Rollback(IDictionary savedState)
        {
            EDDebug.Log("AppInstaller : Rollback");

            base.Rollback(savedState);

            EDDebug.Log("Service : Stop");
            ServiceManager.Stop();

            EDDebug.Log("Service : Delete");
            ServiceManager.Delete();
        }

        public override void Uninstall(IDictionary savedState)
        {
            EDDebug.Log("AppInstaller : Uninstall");

            base.Uninstall(savedState);

            EDDebug.Log("Service : Stop");
            ServiceManager.Stop();

            EDDebug.Log("Service : Delete");
            ServiceManager.Delete();
        }
    }
}
