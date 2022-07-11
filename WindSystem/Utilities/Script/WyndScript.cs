using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindOS.WindSystem.OS;

namespace WindOS.WindSystem.Utilities.Script
{
    class WyndScript
    {
        public static void WyndCompile(string path)
        {
            Console.WriteLine("WyndScript Batch Runner 0.1 (c) 2022 WyndOS Team\n\n");
            //Read each line of the path and compile it.
            //The "code" is terminal commands + some

            //+ some commands:
            // pause 1000
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    if (line.StartsWith("rmdir"))
                    {
                        //rmdir 0:\test
                        try
                        {
                            string DirToRemove = line.Replace("rmdir", "").Trim();
                            Commands.rmdir(DirToRemove);
                        }
                        catch
                        {

                        }

                    }
                    else if (line.StartsWith("mkdir"))
                    {
                        //mkdir 0:\test
                        string DirToCreate = line.Replace("mkdir", "").Trim();
                        Commands.mkdir(DirToCreate);
                    }
                    else if (line.StartsWith("touch"))
                    {
                        //touch 0:\test.txt
                        string FileToCreate = line.Replace("touch", "").Trim();
                        Commands.touch(FileToCreate);
                    }
                    else if (line.StartsWith("rmfile"))
                    {
                        //rmfile 0:\test.txt
                        try
                        {
                            string FileToRemove = line.Replace("rmfile", "").Trim();
                            Commands.rmfile(FileToRemove);
                        }
                        catch
                        {
                            Error.ErrorHandler.Error("FileSystem:deletefile");
                        }

                    }
                    else if (line.StartsWith("dir"))
                    {
                        Commands.dir();
                    }
                    else if (line.StartsWith("cd"))
                    {
                        try
                        {
                            string DirectoryToSwitchTo = line.Replace("cd", "").Trim();
                            Commands.cd(DirectoryToSwitchTo);

                        }
                        catch
                        {
                            Error.ErrorHandler.Error("FileSystem:cd");
                        }
                    }
                    else if (line == "shutdown")
                    {
                        Commands.shutdown();
                    }
                    else if (line == "reboot")
                    {
                        Commands.reboot();
                    }
                    else if (line == "cls")
                    {
                        Commands.cls();
                        Console.WriteLine();
                    }
                    else if (line == "edit")
                    {
                        Commands.edit();
                    }
                    else if (line == "sysconfig")
                    {
                        Commands.sysconfig();
                    }
                    else if (line == "sysinf")
                    {
                        Commands.sysinf();
                    }
                    else if (line.StartsWith("echo"))
                    {
                        string StringToEcho = line.Replace("echo", "").Trim();
                        Commands.echo(StringToEcho);
                    }
                    else if (line == "about")
                    {
                        Commands.about();
                    }
                    else if (line == "eggy")
                    {
                        Commands.easterEgg();
                    }
                    else if (line == "home")
                    {
                        Commands.home();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[!] Command " + "\"" + line + "\"" + " is unknown [!]");
                        Console.ForegroundColor = OSRegistry.userForegroundColor;
                        WriteToLog.writeToLog("IncorrectCommand " + line + " at " + DateTime.Now.ToString());
                    }
                }
            } else
            {
                Error.ErrorHandler.Error("FileSystem:nofile");
            }
            
        }
    }
}
