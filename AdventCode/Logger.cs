using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    
    public static class Logger
    {
        static StreamWriter sw_Writer;

        public static void SetFile(string filename)
        {
            if(File.Exists(filename))
                File.Delete(filename);
            sw_Writer = new StreamWriter(filename);
        }
        public static void CloseFile()
            { sw_Writer.Close(); }

        public static void Log(string message)
        {
            sw_Writer.WriteLine(message);
        }
        public static void ConsoleLog(string message)
        {
            Console.WriteLine(message);
            sw_Writer.WriteLine(message);
        }
    }
}
