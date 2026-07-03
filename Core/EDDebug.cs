using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace EDVirtualCOM2TCP
{
    public static class EDDebug
    {

        private static string Filename
        {
            get
            {
                Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
                string filename = Path.Combine(Directory.GetParent(ass.Location).FullName, ass.GetTypes().First().Namespace + ".log");
                return filename;
            }
        }

        public static void CheckFile()
        {
            string filename= Filename;
            if ( ! File.Exists(filename))
                return;
            if (!Settings.LogEnabled)
                return;
            FileInfo f = new FileInfo(filename);
            if( f.Length > 1024 * 1024 * 10)
            {
                string[] lines = File.ReadAllLines(filename);
                long nbLines=lines.LongLength / 2;
                if (nbLines > int.MaxValue)
                    nbLines = int.MaxValue;
                File.WriteAllLines(filename, lines.Skip((int)nbLines).ToArray());
            }

        }

        public static void Log(string msg)
        {
            if (!Settings.LogEnabled)
                return;
            using (StreamWriter w = File.AppendText(Filename))
            {
                w.WriteLine(DateTime.Now.ToShortDateString()
                    + " " + DateTime.Now.ToLongTimeString()
                    + "\t" + msg);
            }

        }

        public static void LogLine(string msg)
        {
            if (!Settings.LogEnabled)
                return;
            using (StreamWriter w = File.AppendText(Filename))
            {
                w.WriteLine(msg);
            }

        }
    }

}
