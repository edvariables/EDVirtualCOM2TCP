using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace EDVirtualCOM2TCP
{
    public static class ServiceManager
    {
        //        sc.exe create "FileMonitorService" binPath= "C:\Services\FileMonitor\MyWindowsService.exe" start= auto
        //sc.exe description "FileMonitorService" "Monitors directory for file changes"
        //sc.exe start "FileMonitorService"

        public static string ExeFileName
        {
            get
            {
                string sDir = Environment.GetFolderPath( Environment.SpecialFolder.System);
                return Path.Combine(sDir, "sc.exe");
            }
        }

        /**
         * Create
         * */
        public static void Create()
        {
            Create(false);
        }

        /**
         * Create
         * */
        public static void Create(bool ifNotExists) 
        {
            if (ifNotExists && Exists())
                return;
            string serviceFileName = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName
                , "EDVirtualCOM2TCP.Service.exe");
            string startMode = "auto";//delayed-
            string parameters = @"create """ + Settings.ServiceName + @""" binPath=""" + serviceFileName + @""" start="+startMode;// description=""(ED/Calisto) Passerelle Virtual COM <=> Ethernet""";
            ICommandFile.Run(ExeFileName, parameters);

            parameters = @"description """ + Settings.ServiceName + @""" ""(ED/Calisto) Passerelle Virtual COM <=> Ethernet""";
            ICommandFile.Run(ExeFileName, parameters);
        }

        /**
         * Remove
         * */
        public static void Delete()
        {
            string parameters = @"delete """ + Settings.ServiceName + @"""";
            ICommandFile.Run(ExeFileName, parameters);
        }

        /**
         * Exists
         * */
        public static bool Exists() {

            ServiceController sc = new ServiceController(Settings.ServiceName);
            try
            {
                ServiceControllerStatus status = sc.Status;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * Start service
         * */
        public static ServiceControllerStatus Status
        {
            get
            {

                ServiceController sc = new ServiceController(Settings.ServiceName);

                try
                {
                    return sc.Status;
                }
                catch
                {
                    return ServiceControllerStatus.Stopped;
                }
            }
        }

        /**
         * Start service
         * */
        public static bool Start()
        {

            ServiceController sc = new ServiceController(Settings.ServiceName);

            try
            {
                sc.Start();

                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                EDDebug.Log("Timeout lors du démarrage du service");

                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    EDDebug.Log("Start service exception : " + ex.InnerException.Message);
                else
                    EDDebug.Log("Start service exception : " + ex.Message);
                return false;
            }

            return true;
        }

        /**
         * Stop service
         * */
        public static bool Stop()
        {
            EDDebug.Log("Service.Stop()");

            ServiceController sc = new ServiceController(Settings.ServiceName);

            try
            {
                sc.Stop();

                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                EDDebug.Log("Timeout lors de l'arrêt du service");

                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    EDDebug.Log("Stop service exception : " + ex.InnerException.Message);
                else
                    EDDebug.Log("Stop service exception : " + ex.Message);
                return false;
            }

            return true;
        }
    }
}
