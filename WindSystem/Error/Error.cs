using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindOS.WindSystem.OS;
using WindOS.WindSystem.Utilities;

namespace WindOS.WindSystem.Error
{
    class ErrorHandler
    {
        public static void Error(string errorString)
        {
            if(errorString == "bootError:FileSystemInit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] OS Error: Boot Error: FileSystem could not load [!]");
                WriteToLog.writeToLog("FileSystem could not load at " + DateTime.Now.ToString());
                SysCommand.sysShutDown("fatal");
                
            } 
            else if(errorString == "FileSystem:removedir")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: Could not remove directory [!]");
                WriteToLog.writeToLog("Could not remove directory at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
            else if (errorString == "logerror:writeToLog")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Log Error: Could not stash log [!]");
                WriteToLog.writeToLog("Could not stash log at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
              
            }
            else if(errorString == "FileSystem:createdir")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: Could not create directory [!]");
                WriteToLog.writeToLog("Could not create directory at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
            else if(errorString == "FileSystem:createdfile")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: Could not create file [!]");
                WriteToLog.writeToLog("Could not create file at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
            else if(errorString == "FileSystem:deletefile")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: Could not delete file [!]");
                WriteToLog.writeToLog("Could not delete file at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
            else if(errorString == "FileSystem:cd")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: Could not change directory! [!]");
                WriteToLog.writeToLog("Could not change directory at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
            else if (errorString == "FileSystem:nofile")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: File does not exist [!]");
                WriteToLog.writeToLog("Could not read file at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
        }
    }
}
