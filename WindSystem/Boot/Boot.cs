using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace WindOS.WindSystem.Boot
{
    class Boot
    {
        public static void SysBoot()
        {
            Console.Clear();
            Console.WriteLine("Welecome to WyndOS!\n");
        }

        public static void SysSetup()
        {
            if (Directory.Exists("0:\\TEST"))
            {
                Console.Clear();
                Console.Beep();
                Console.Write("Welecome to WyndOS ");
                Console.Write("Setup!\n");
                Console.WriteLine("\nStarting Setup...\n");
                try
                {
                    File.Delete("0:\\TEST\\DirInTest\\Readme.txt");
                    Console.WriteLine("Building Filesystem -> 0:\\WyndOS");
                    Directory.CreateDirectory("0:\\WyndOS");

                }
                catch (Exception ex)
                {

                }
                try
                {
                    File.Delete("0:\\Kudzu.txt");
                    Console.WriteLine("Building Filesystem -> 0:\\WyndOS\\Data");
                    Directory.CreateDirectory("0:\\WyndOS\\Data");

                }
                catch (Exception ex)
                {

                }

                try
                {
                    File.Delete("0:\\Root.txt");
                    Console.WriteLine("Building Filesystem -> 0:\\WyndOS\\Libs");

                }
                catch (Exception ex)
                {

                }
                try
                {
                    Directory.Delete("0:\\TEST\\DirInTest");
                    Console.WriteLine("Cleaning up footprint...");
                    Directory.Delete("0:\\Dir Testing");
                    Console.WriteLine("Building Filesystem -> 0:\\WyndOS\\Apps");

                }
                catch (Exception ex)
                {

                }
                try
                {
                    Directory.Delete("0:\\TEST");
                    Console.WriteLine("Building Filesystem -> Writing System Files...");
                    //Setup system directories.



                    Directory.CreateDirectory("0:\\WyndOS\\Prefs");
                    string prefsText =
                        "\nstatic: noPrefs";
                    File.WriteAllText("0:\\WyndOS\\Prefs\\prefs.pfs", prefsText);
                    Directory.CreateDirectory("0:\\Help");
                    
                    //Setup helpFile
                    string helpText =
                        "Welecome to WyndOS Docs!\nCommands:\n|\n|> FileSystem Commands\nfstype - Determine the filesystem type\ndir - List contents of current directory\ncd - Change current directory\nmkdir - Create a directory at given path" +
                        "\nrmdir - Delete directory at given path\n del - Delete file at given path\n read - Display the contents of a file at a given path\ntouch - Create a new file at given path\n\n|\n|> System Commands\nshutdown - Shutdown the computer. Use -now to shutdown immediantly.\ncls - Clear the screen" +
                        "\npwd - Show current working directory" +
                        "\nedit - Open a file at a given path in a text editor. Use -new to create new\nsysinf - Display system information" +
                        "\nsysconfig - Access system settings\ndrive - Display drive contents, and detailed info.\ncp - Copy a file to given path\nmv - Move a file to given path";
                    File.WriteAllText("0:\\Help\\Help.txt", helpText);

                }
                catch (Exception ex)
                {

                }




                string readmeText = "Welecome to WyndOS! Please refer to 0:\\Help\\Help.txt for learning commands and getting started.";
                File.WriteAllText("0:\\Readme.txt", readmeText);
                string password = "root";
                File.WriteAllText("0:\\WyndOS\\Prefs\\usrconfig.pfs", password);
                Directory.CreateDirectory("0:\\WyndOS\\Logs");
                File.WriteAllText("0:\\WyndOS\\Logs\\System.log", "SetupComplete");
                                                
                Console.WriteLine("Cleaning up temp files....");



            }
        }
    }
}
