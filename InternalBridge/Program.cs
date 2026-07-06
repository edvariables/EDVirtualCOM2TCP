using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDVirtualCOM2TCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cnc = "COM6"
                , tcp = "127.0.0.1:4441";

            foreach (string arg in args)
            {
                string param = arg.Split('=')[0];
                switch (param.Trim().ToUpper())
                {
                    case "COM":
                    case "CNC":
                        cnc = arg.Substring(param.Length+1).Trim();
                        break;
                    case "TCP":
                        tcp = arg.Substring(param.Length+1).Trim();
                        break;
                    case "help":
                        Console.WriteLine("options : CNC=%CNC name% TCP=%tcp address%:%tcp port%");
                        Console.WriteLine("Exemple : {0} CNC=COM5 TCP=127.0.0.1:4441", "EDVirtualCOM2TCP.InternalBridge");
                        break;

                    default:
                        Console.WriteLine("Argument inconnu : " + param);
                        break;
                }
            }

            try
            {
                using (Bridge bridge = new Bridge(cnc, tcp))
                {
                    
                    while (true)
                    {
                        bridge.Start();
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
