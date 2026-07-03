using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/**
 * Les paramètres par défaut sont dans Settings.Settings.
 * Toutefois, les valeurs modifiées le sont pour tous les utilisateurs du PC. 
 * Les données sont donc enregistrées dans un fichier INI.
 * Sinon; on avait une confusion entre l'utilisateur Système pour le service.
 * 
 * */

namespace EDVirtualCOM2TCP
{
    public static class Settings
    {

        public static string ServiceName
        {
            get
            {
                return "EDVirtualCOM2TCP";
            }
        }

        public static string IP_Address
        {
            get
            {
                return IniFile.ReadValue("IP_Address", null, EDVirtualCOM2TCP.Properties.Settings.Default.IP_Address);
            }
            set
            {
                IniFile.WriteValue("IP_Address", value);
            }
        }

        public static int IP_Port
        {
            get
            {
                return int.Parse(IniFile.ReadValue("IP_Port", null, EDVirtualCOM2TCP.Properties.Settings.Default.IP_Port.ToString()));
            }
            set
            {
                IniFile.WriteValue("IP_Port", value.ToString());
            }
        }

        public static int Service_Delay
        {
            get
            {
                return int.Parse(IniFile.ReadValue("Service_Delay", null, EDVirtualCOM2TCP.Properties.Settings.Default.service_delay.ToString()));
            }
            set
            {
                IniFile.WriteValue("Service_Delay", value.ToString());
            }
        }

        public static int COM_num
        {
            get
            {
                return int.Parse(IniFile.ReadValue("COM_num", null, EDVirtualCOM2TCP.Properties.Settings.Default.COM_num.ToString()));
            }
            set
            {
                IniFile.WriteValue("COM_num", value.ToString());
            }
        }

        public static string Com0Com_path
        {
            get
            {
                return IniFile.ReadValue("Com0Com_path", null, EDVirtualCOM2TCP.Properties.Settings.Default.com0com_path);
            }
            set
            {
                IniFile.WriteValue("Com0Com_path", value);
            }
        }

        public static string Hub4Com_path
        {
            get
            {
                return IniFile.ReadValue("Hub4Com_path", null, EDVirtualCOM2TCP.Properties.Settings.Default.hub4com_path);
            }
            set
            {
                IniFile.WriteValue("Hub4Com_path", value);
            }
        }

        public static string Hub4Com_options
        {
            get
            {
                return IniFile.ReadValue("Hub4Com_options", null, EDVirtualCOM2TCP.Properties.Settings.Default.hub4com_options);
            }
            set
            {
                IniFile.WriteValue("Hub4Com_options", value);
            }
        }

        public static string Hub4Com_Download
        {
            get
            {
                return IniFile.ReadValue("Hub4Com_Download", null, EDVirtualCOM2TCP.Properties.Settings.Default.hub4com_download);
            }
            set
            {
                IniFile.WriteValue("Hub4Com_Download", value);
            }
        }
        public static string Com0Com_Download
        {
            get
            {
                return IniFile.ReadValue("Com0Com_Download", null, EDVirtualCOM2TCP.Properties.Settings.Default.com0com_download);
            }
            set
            {
                IniFile.WriteValue("Com0Com_Download", value);
            }
        }
        public static bool LogEnabled
        {
            get
            {
                return bool.Parse(IniFile.ReadValue("LogEnabled", null, true.ToString()));
            }
            set
            {
                IniFile.WriteValue("LogEnabled", value.ToString());
            }
        }

        public static void Save()
        {
            EDVirtualCOM2TCP.Properties.Settings.Default.Save();
        }
    }
}
