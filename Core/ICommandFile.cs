using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDVirtualCOM2TCP
{
    internal static class ICommandFile
    {

        private static readonly Hashtable _threadProcesses = new Hashtable();

        public static Thread RunAsThread(string exeFileName, string parameters)
        {
            Thread thread = new Thread(Run_Callback);
            Process process = new Process();
            Hashtable args = new Hashtable
            {
                { "exeFileName", exeFileName },
                { "parameters", parameters },
                { "process", process }
            };
            
            thread.Start( args );

            _threadProcesses.Add( thread.GetHashCode(), process);
            return thread;
        }
        public static void Run_Callback(Object data)
        {
            Hashtable args = (Hashtable)data;
            Run((string)args["exeFileName"], (string)args["parameters"], (Process)args["process"]);
        }

        public static string Run(string exeFileName, string parameters)
        {
            return Run(exeFileName, parameters, null);
        }
        private static string Run(string exeFileName, string parameters, Process cmd)
        {
            if( ! File.Exists(exeFileName))
                throw new Exception("Fichier introuvable : " + exeFileName);
            
            if(cmd == null)
                cmd = new Process();
            cmd.StartInfo.FileName = exeFileName;
            cmd.StartInfo.WorkingDirectory = Directory.GetParent(cmd.StartInfo.FileName).FullName;
            cmd.StartInfo.Arguments = parameters;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            string com0com = "\""
                + exeFileName + "\""
                + " " + parameters;
            EDDebug.Log("Run > " + com0com);

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            
            string result = cmd.StandardOutput.ReadToEnd();
            EDDebug.Log("Result > " + result);

            return result;
        }

        public static bool StopThread(Thread thread)
        {
            if (!_threadProcesses.ContainsKey(thread.GetHashCode()))
                return false;
            Process process = ((Process)_threadProcesses[thread.GetHashCode()]);
            if (!process.HasExited)
                try
                {
                    process.Kill();
                }
                catch { }
            try
            {
                thread.Abort();
            }
            finally
            {
                _threadProcesses.Remove(thread.GetHashCode());
            }
            return true;
        }

        public static bool IsProcessRunning(Thread thread)
        {
            if (!_threadProcesses.ContainsKey(thread.GetHashCode()))
                return false;
            Process process = ((Process)_threadProcesses[thread.GetHashCode()]);
            bool hasExited = true;
            try
            {
                hasExited = process.HasExited;
            }
            catch { }
            return !hasExited;
        }
    }
}
