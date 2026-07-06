using EDVirtualCOM2TCP.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDVirtualCOM2TCP
{
    /**
     * TODO : Ce module réinitialise Com0Com sans tenir compte d'autres usages sur l'ordinateur
     * 
     * */
    /**
     * 
     * */
    public static class Com0Com
    {
        public static int CreatedPair_CNC = -1;
        public static string CreatedPair_COM = String.Empty;
        public static int CreatedPair_COMNum = -1;

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
            result = result.Replace("\r", String.Empty).TrimEnd('\n');
            if( result.Length == 0) 
                return Array.Empty<string>();
            return result.Split('\n');
        }

        public static bool CreatePair()
        {
            int availableCom = AvailableCOM();
            if( ! Settings.Com0Com_CreateCOM)
            {
                CreatedPair_CNC = -1;
                CreatedPair_COMNum = availableCom - 2;
                CreatedPair_COM = "COM" + CreatedPair_COMNum.ToString();
                return true;
            }

            int index = Busynames().Length;
            do
            {
                string cmd = "--silent install " + index + " PortName=COM" + availableCom.ToString();
                if (Settings.Bridge_Hub4Com)
                    cmd += ",EmuBR=yes -";
                else
                    cmd += ",EmuBR=no PortName=COM" + (availableCom + 1).ToString();
                EDDebug.Log("> " + cmd);

                string result = Run(cmd);
                if( ! result.Contains("is already used")
                    && result.Contains(" logged as "))
                {
                    Match match=Regex.Match(result, @"^\s*CNCA(?<cnc>\d+)\sPortName=COM(?<com>\d+)");
                    if (match.Success)
                    {
                        CreatedPair_CNC = int.Parse(match.Groups["cnc"].Value);
                        CreatedPair_COMNum = int.Parse(match.Groups["com"].Value);
                        CreatedPair_COM = "COM" + CreatedPair_COMNum.ToString();

                        return true;
                    }

                }
            } while (index++ < 127);
            return false;
        }

        public static bool RemoveAll()
        {
            string[] busynames = Busynames();
            string coms = String.Join(" ", busynames);
            int killMore = 1;//TODO Bloque si on a COM3 COM5 COM9
            for (int i = 0; i < busynames.Length + killMore; i++)
            {
                string cmd = "--silent remove " + i.ToString();
                string result = Run(cmd);
            }

            CreatedPair_CNC = -1;
            CreatedPair_COM = String.Empty;
            CreatedPair_COMNum = -1;
            return true;
        }

        public static int AvailableCOM()
        {
            int comNum = Settings.COM_num;
            try
            {
                foreach(string busyname in Busynames())
                {
                    int usedNum = int.Parse(busyname.Substring(3));
                    if (usedNum >= comNum)
                        comNum = usedNum + 1;
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
