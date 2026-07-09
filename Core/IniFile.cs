using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace EDVirtualCOM2TCP
{
    class IniFile
    {
        private static string _Path;
        private string Path;
        private static string EXE;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        static IniFile()
        {
            EXE = Assembly.GetExecutingAssembly().GetTypes().First().Namespace;
            _Path = System.IO.Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName,EXE + ".ini");
            if (!File.Exists(_Path))
                File.WriteAllText(_Path, "#" + EXE);
        }
        public IniFile(string IniPath = null)
        {
            EXE = Assembly.GetExecutingAssembly().GetName().Name;
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public static string ReadValue(string Key, string Section=null, string defaultValue = null)
        {
            var RetVal = new StringBuilder(1024);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 1024, _Path);
            if (RetVal.Length > 0)
                return RetVal.ToString();
            return defaultValue;
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(1024);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 1024, Path);
            return RetVal.ToString();
        }

        public static void WriteValue(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, _Path);
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section ?? EXE).Length > 0;
        }
    }
}