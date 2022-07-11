using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindOS.WindSystem.Help
{
    class HelpSystem
    {
        public static void displayHelp(string command)
        {
            if(command == "rmdir")
            {
                Console.WriteLine("rmdir - Delete a folder at a path");
            }
            else if(command == "mkdir")
            {
                Console.WriteLine("mkdir - Create a folder at a path");
            }
            else if(command == "touch")
            {
                Console.WriteLine("touch - Create a file at a path");
            }
            else if(command == "rmfile")
            {
                Console.WriteLine("rmfile - Delete a file at a path");
            }
            else if(command == "dir")
            {
                Console.WriteLine("dir - List all the files and folders in a path");
            }
            else if(command == "edit")
            {
                Console.WriteLine("edit - Open an editor app to edit text files");
            }
            else if(command == "sysinf")
            {
                Console.WriteLine("sysinf - Display system information");
            }
            else if(command == "sysconfig")
            {
                Console.WriteLine("sysconfig - Open system settings");
            }
            else if(command == "shutdown")
            {
                Console.WriteLine("shutdown - Shutdown the computer");
            }
            else if(command == "reboot")
            {
                Console.WriteLine("reboot - Reboot the computer");
            }
            else if (command == "echo")
            {
                Console.WriteLine("echo - Print text to the console");
            }
        }
    }
}
