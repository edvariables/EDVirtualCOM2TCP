using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDVirtualCOM2TCP
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EDDebug.Log("Program " + Assembly.GetExecutingAssembly().FullName);
            foreach (string arg in args)
            {
                EDDebug.Log("Arg : " + arg);
                //    switch (arg)
                //    {
                //        case "Setup-Install":
                //            Setup_Install();
                //            break;
                //        case "Setup-Commit":
                //            Setup_Commit();
                //            break;
                //        case "Setup-Rollback":
                //        case "Setup-Uninstall":
                //            Setup_Uninstall();
                //            break;
                //    }
            }
            Application.Run(new FMain());
        }

        //static void Setup_Install()
        //{
        //    if (!Com0Com.IsInstalled)
        //    {
        //        if (MessageBox.Show("Le composant Com0Com n'est pas installé."
        //            + "\nVoulez-vous le télécharger ?"
        //            , "Installation de EDVirtualCOM2TCP"
        //            , MessageBoxButtons.YesNo
        //            , MessageBoxIcon.Question)
        //            == DialogResult.Yes)
        //        {
        //            Com0Com.Download();

        //            MessageBox.Show("Quand l'installation de Com0Com sera effectuée, \ncliquez sur Ok pour poursuivre le démarrage."
        //            , "Installation de EDVirtualCOM2TCP"
        //            , MessageBoxButtons.OK
        //            , MessageBoxIcon.Warning);

        //        }
        //    }
        //}

        //static void Setup_Commit()
        //{
        //    EDDebug.Log("Service : Delete");
        //    ServiceManager.Delete();

        //    EDDebug.Log("Service : Create");
        //    ServiceManager.Create();

        //    EDDebug.Log("Service : " + ServiceManager.Status.ToString());
        //    //Normalement, AppInstaller.Commit devrait avoir fait le boulot
        //    ServiceManager.Start();
        //}

        //static void Setup_Uninstall()
        //{
        //    EDDebug.Log("Service : Stop");
        //    ServiceManager.Stop();

        //    EDDebug.Log("Service : Delete");
        //    ServiceManager.Delete();
        //}
    }
}
