using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindOS.WindSystem.Utilities
{
    class WriteToLog
    {
        public static void writeToLog(string errorString)
        {
            try
            {
                string previousText = File.ReadAllText("0:\\WyndOS\\Logs\\System.log");
                File.AppendAllText("0:\\WyndOS\\Logs\\System.log", "\n" + errorString);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //Error.ErrorHandler.Error("logerror:writeToLog");
            }
        }
    }
}
