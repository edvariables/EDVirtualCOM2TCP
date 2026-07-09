using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
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

            if( !IsAdministrator())
            {
                MessageBox.Show("Ce module nécessite les droits Administrateur. Ouvrez le programme par un clic-droit, Exécuter en tant qu'administrateur."
                    , "EDVirtualCOM2TCP"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Stop);
                return;
            }
            if (args.Length>0)
            {
                EDDebug.Log("App arguments : {0}", args.Length);
                foreach (string arg in args)
                {
                    EDDebug.Log(arg);
                }
            }
            Application.Run(new FMain());
        }

        public static bool IsAdministrator()
            {
                using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                {
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
            }
        }
}
