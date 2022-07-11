using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace WindOS.WindSystem.OS
{
    class SysCommand
    {
        public static void sysShutDown(string code)
        {
            if(code != "fatal")
            {
                Console.WriteLine("\nWyndOS is shutting down...");
                Thread.Sleep(2000);
                Sys.Power.Shutdown();

            } else
            {
                Sys.Power.Shutdown();
            }
            
        }

        public string getSystemState()
        {
            //TODO: Work on this
            return "";
        }

        public static void initSysReg()
        {
            //Load user foreground/background prefs, username, user password

            //Basic Holding Text
            OSRegistry.userName = "root";
            OSRegistry.currentDirectory = "0:\\";
            OSRegistry.userForegroundColor = ConsoleColor.White;
        }
    }
}
