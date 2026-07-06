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
    public static class ICommandFile
    {
        public delegate void ProcessExited();

        private static readonly Hashtable _threadProcesses = new Hashtable();

        public static Thread RunAsThread(string exeFileName, string parameters, ICommandFile.ProcessExited processExited = null)
        {
            Thread thread = new Thread(Run_Callback);
            Process process = new Process();
            Hashtable args = new Hashtable
            {
                { "exeFileName", exeFileName },
                { "parameters", parameters },
                { "process", process },
                { "processExited", processExited }
            };
            
            thread.Start( args );

            _threadProcesses.Add( thread.GetHashCode(), process);
            return thread;
        }
        public static void Run_Callback(Object data)
        {
            Hashtable args = (Hashtable)data;
            Run((string)args["exeFileName"], (string)args["parameters"], (Process)args["process"], (ICommandFile.ProcessExited)args["processExited"]);
        }

        public static string Run(string exeFileName, string parameters)
        {
            return Run(exeFileName, parameters, null);
        }
        private static string Run(string exeFileName, string parameters, Process cmd, ICommandFile.ProcessExited processExited = null)
        {
            if( ! File.Exists(exeFileName))
                throw new Exception("Fichier introuvable : " + exeFileName);

            string com0com = "\""
                + exeFileName + "\""
                + " " + parameters;
            EDDebug.Log("Run > " + com0com);

            if (cmd == null)
                cmd = new Process();
            cmd.StartInfo.FileName = exeFileName;
            cmd.StartInfo.WorkingDirectory = Directory.GetParent(cmd.StartInfo.FileName).FullName;
            cmd.StartInfo.Arguments = parameters;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;


            StringBuilder result = new StringBuilder();
            
            cmd.OutputDataReceived += (sender, args) => result.AppendLine(result.Length < 1024 * 1024 ? args.Data : "");
            
            cmd.Start();

            cmd.BeginOutputReadLine();

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

            cmd.WaitForExit();
            cmd.CancelOutputRead();

            EDDebug.LogLine("Return >" + result.ToString());
            if (processExited != null)
                processExited.Invoke();
            return result.ToString();
        }

        public static bool StopThread(Thread thread)
        {
            try
            {
                int hashCode = thread.GetHashCode();

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
                    try
                    {
                        _threadProcesses.Remove(thread.GetHashCode());
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                EDDebug.Log("StopThread : " + (ex.InnerException == null ? ex.Message : ex.InnerException.Message));
                return false;
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
