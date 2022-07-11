using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using WindOS.WindSystem.Error;
using WindOS.WindSystem.WindConsole;
using WindOS.WindSystem.OS;
using WindOS.WindSystem.Boot;
using System.IO;
using System.Threading;
using WindOS.WindSystem.Resources;
using Cosmos.System.Graphics;

namespace WindOS
{
    public class Kernel : Sys.Kernel
    {
        public CosmosVFS fs;
        public static VGAScreen VScreen = new VGAScreen();

        protected override void BeforeRun()
        {
            //Handle the filesystem Creation
            fs = new Sys.FileSystem.CosmosVFS();

            try
            {
               VFSManager.RegisterVFS(fs);
               VFSManager.SetFileSystemLabel("0:\\", "WindOS LocalDisk (0:\\)");
            }
            catch
            {
                ErrorHandler.Error("bootError:FileSystemInit");
            }

            SysCommand.initSysReg();
            Boot.SysBoot();
            if(Directory.Exists("0:\\TEST"))
            {
                Boot.SysSetup();
            } else
            {

            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[||------------]10%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[||||----------]20%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[||||||--------]30%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[|||||||-------]40%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[||||||||------]50%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[||||||||||----]60%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[|||||||||||---]70%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[||||||||||||--]80%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[|||||||||||||-]90%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSTornado);
            Console.Write("[||||||||||||||]100%");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(WindSystem.Resources.ASCIIArt.wyndOSIcon);
            Console.WriteLine("Welecome!");
            Console.WriteLine();

            Console.ForegroundColor = OSRegistry.userForegroundColor;


        }

        protected override void Run()
        {
            
            WindConsole.RunWindConsole();
            
        }
    }
}
