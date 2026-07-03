using EDVirtualCOM2TCP.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EDVirtualCOM2TCP
{
    public static class Com0Com
    {
        public static string ExeFileName
        {
            get
            {
                return Path.Combine( Environment.ExpandEnvironmentVariables(Settings.Com0Com_path), "setupc.exe");
            }
        }

        public static string Run(string parameters)
        {
            return ICommandFile.Run(ExeFileName, parameters);
        }

        public static string[] Busynames()
        {
            string cmd = "busynames COM?*";

            string result = Run(cmd);
            return result.Replace("\r", String.Empty).TrimEnd('\n').Split('\n');
        }

        public static bool CreatePair()
        {
            int availableCom = AvailableCOM();
            int index = Busynames().Length;
            string cmd = "--silent install " + index + " PortName=COM" + availableCom.ToString() + ",EmuBR=yes -";
            EDDebug.Log("> " + cmd);

            string result = Run(cmd);

            EDDebug.Log(result);

            return false;
        }

        public static bool RemoveAll()
        {
            string[] busynames = Busynames();
            string coms = String.Join(" ", busynames);
            for (int i = 0; i < busynames.Length; i++)
            {
                string cmd = "--silent remove " + i.ToString();
                string result = Run(cmd);
            }

            return true;
        }

        public static int AvailableCOM()
        {
            int comNum = Settings.COM_num;
            try
            {
                foreach(string busyname in Busynames())
                {
                    if (int.Parse(busyname.Substring(3)) >= comNum)
                        comNum++;
                }
            }
            catch (Exception)
            {
                return comNum;
            }
            return comNum;
        }

        public static bool IsInstalled
        {
            get
            {
                return File.Exists(ExeFileName);
            }
        }

        public static void Download()
        {
            string url = Settings.Com0Com_Download;
            System.Diagnostics.Process.Start(url);
        }

        public static void OpenGraphic()
        {
            string fileName = Path.Combine(Environment.ExpandEnvironmentVariables(Settings.Com0Com_path), "setupg.exe");
            Process.Start(fileName);
        }
    }
}
