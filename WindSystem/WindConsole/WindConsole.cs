using System;
using WindOS.WindSystem.OS;
using WindOS.WindSystem.Utilities;

namespace WindOS.WindSystem.WindConsole
{
    class WindConsole
    {
        public static void RunWindConsole()
        {
            int x = Console.CursorLeft, y = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(DateTime.Now.ToString() + "                                                       " + "WyndOS\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ForegroundColor = OSRegistry.userForegroundColor;
            Console.BackgroundColor = OSRegistry.userBackgroundColor;
            Console.SetCursorPosition(x, y);

            string input;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@" + OSRegistry.userName + " ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(OSRegistry.currentDirectory);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("~>");
            Console.ForegroundColor = ConsoleColor.White;

            input = Console.ReadLine();

            if(input.StartsWith("rmdir"))
            {
                //rmdir 0:\test
                try
                {
                    string DirToRemove = input.Replace("rmdir", "").Trim();
                    Commands.rmdir(DirToRemove);
                } catch
                {

                }
                
            } 
            else if(input.StartsWith("mkdir"))
            {
                //mkdir 0:\test
                string DirToCreate = input.Replace("mkdir", "").Trim();
                Commands.mkdir(DirToCreate);
            } 
            else if(input.StartsWith("touch"))
            {
                //touch 0:\test.txt
                string FileToCreate = input.Replace("touch", "").Trim();
                Commands.touch(FileToCreate);
            }
            else if(input.StartsWith("rmfile"))
            {
                //rmfile 0:\test.txt
                try
                {
                    string FileToRemove = input.Replace("rmfile", "").Trim();
                    Commands.rmfile(FileToRemove);
                } catch
                {
                    Error.ErrorHandler.Error("FileSystem:deletefile");
                }
                
            }
            else if(input.StartsWith("dir"))
            {
                Commands.dir();
            }
            else if(input.StartsWith("cd"))
            {
                try
                {
                    string DirectoryToSwitchTo = input.Replace("cd", "").Trim();
                    Commands.cd(DirectoryToSwitchTo);

                }
                catch
                {
                    Error.ErrorHandler.Error("FileSystem:cd");
                }
            }
            else if (input == "shutdown")
            {
                Commands.shutdown();
            }
            else if (input == "reboot")
            {
                Commands.reboot();
            }
            else if (input == "cls")
            {
                Commands.cls();
                Console.WriteLine();
            }
            else if(input == "edit")
            {
                Commands.edit();
            }
            else if (input == "sysconfig")
            {
                Commands.sysconfig();
            }
            else if (input == "sysinf")
            {
                Commands.sysinf();
            }
            else if (input.StartsWith("echo"))
            {
                string StringToEcho = input.Replace("echo", "").Trim();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Command " + "\"" + input + "\"" + " is unknown [!]");
                Console.ForegroundColor = OSRegistry.userForegroundColor;
                WriteToLog.writeToLog("IncorrectCommand " + input + " at " + DateTime.Now.ToString());
            }



        }

        public static void print(string text)
        {
            Console.Write(text);
        }

        public static void println(string text)
        {
            Console.WriteLine(text);
        }

        public static void printHeader(string title)
        {
            Console.Clear();
            int x = Console.CursorLeft, y = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(title + "                                          ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ForegroundColor = OSRegistry.userForegroundColor;
            Console.BackgroundColor = OSRegistry.userBackgroundColor;
            Console.SetCursorPosition(x, y);
        }
    }
}
