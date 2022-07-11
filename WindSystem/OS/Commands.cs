using Cosmos.System.FileSystem.VFS;
using System;
using System.IO;
using WindOS.WindSystem.SettingsUI;
using WindOS.WindSystem.Utilities;
using Sys = Cosmos.System;

namespace WindOS.WindSystem.OS
{
    class Commands
    {
        //File system commands
        public static void rmdir(string args)
        {
            //Delete dir
            try
            {
                if (args != "")
                {
                    Directory.Delete(args);
                } else
                {
                    Help.HelpSystem.displayHelp("rmdir");
                }
                
            } catch(Exception ex)
            {
                Error.ErrorHandler.Error("FileSystem:removedir");
            }
            
        }

        public static void mkdir(string args)
        {
            //Create dir
            try
            {
                if (args != "")
                {
                    Directory.CreateDirectory(args);
                }
                else
                {
                    Help.HelpSystem.displayHelp("mkdir");
                }

            }
            catch (Exception ex)
            {
                Error.ErrorHandler.Error("FileSystem:createdir");
            }
        }

        public static void touch(string args)
        {
            //Create file
            try
            {
                if(args != "")
                {
                    File.WriteAllText(args, "");
                }
                else
                {
                    Help.HelpSystem.displayHelp("touch");
                }

            }
            catch (Exception ex)
            {
                Error.ErrorHandler.Error("FileSystem:createdfile");
            }
        }

        public static void rmfile(string args)
        {
            //Delete file
            try
            {
                if (args != "")
                {
                    File.Delete(args);
                }
                else
                {
                    Help.HelpSystem.displayHelp("rmfile");
                }

            }
            catch (Exception ex)
            {
                Error.ErrorHandler.Error("FileSystem:deletefile");
            }
        }

        public static void dir()
        {
            try
            {
                var directory_list = VFSManager.GetDirectoryListing(OSRegistry.currentDirectory);
                if (directory_list.Count == 0)
                {
                    Console.WriteLine("Directory is empty.");
                }
                else
                {
                    foreach (var directoryEntry in directory_list)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("|>");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(directoryEntry.mName);
                        Console.Write(" | Size: " + directoryEntry.GetUsedSpace() + " bytes");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\n|\n");
                        Console.ForegroundColor = ConsoleColor.White;


                        //|>dir
                        //|
                    }
                }
            } catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: Could not delete file [!]");
                WriteToLog.writeToLog("Issue listing directories at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
        }

        public static void cd(string args)
        {
            //if the args == \ then navigate home dir 0:\
            if(Directory.Exists(args))
            {
                OSRegistry.currentDirectory = args;
            }
            else if(args == "\\")
            {
                OSRegistry.currentDirectory = "0:\\";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] File System Error: Directory does not exist [!]");
                WriteToLog.writeToLog("Issue cd'ing to directories at " + DateTime.Now.ToString());
                Console.ForegroundColor = OSRegistry.userForegroundColor;
            }
        }
            

        //Builtin commands

        public static void edit()
        {
            //Open text editor
            MIV.MIV.StartMIV();
        }

        public static void sysinf()
        {
            //Display system info
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("RAM: " + Cosmos.Core.CPU.GetAmountOfRAM().ToString() + " bytes");
            Console.WriteLine("CPU Vendor: " + Cosmos.Core.CPU.GetCPUVendorName().ToString());
            Console.WriteLine("CPU Info: " + Cosmos.Core.CPU.GetCPUBrandString().ToString());
            Console.WriteLine("CPU Uptime: " + Cosmos.Core.CPU.GetCPUUptime().ToString() + " ms");
            Console.WriteLine("OS: " + "WyndOS Version " + OSRegistry.versionString);
            Console.WriteLine("System Footprint: " + System.PlatformID.Other.ToString());
        }

        public static void sysconfig()
        {
            //Display System Settings

            WindConsole.WindConsole.printHeader("WyndOS System Settings");

            WindConsole.WindConsole.println("\n1. User Settings");
            WindConsole.WindConsole.println("2. Back");

            Console.Write("Enter Choice> ");
            string choice = Console.ReadLine();

            if(choice == "1")
            {
                UserSettings.userSettings();
            } else if(choice == "2")
            {
                Console.Clear();
            } else
            {
                Console.Clear();
            }
        }

        public static void shutdown()
        {
            SysCommand.sysShutDown("");
        }

        public static void reboot()
        {
            Sys.Power.Reboot();
        }

        public static void cls()
        {
            Console.Clear();
        }

        public static void echo(string args)
        {
            if (args != "")
            {
                Console.WriteLine(args);
            }
            else
            {
                Help.HelpSystem.displayHelp("echo");
            }
            
        }

        public static void about()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Resources.ASCIIArt.wyndOSIcon);
            Console.Write("Wynd OS Version " + OSRegistry.versionString + " (c) 2022 Wynd OS Team");
            Console.ForegroundColor = OSRegistry.userForegroundColor;
        }
    }
}
