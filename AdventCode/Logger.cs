using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public enum LogLevel
    {
        Trace, Info, Warn, Error
    }
    public static class Logger
    {
        private static StreamWriter sw_Writer;
        private static LogLevel ll_WriteLevel = LogLevel.Trace;
        private static LogLevel ll_ConsoleLevel = LogLevel.Trace;

        public static LogLevel WriteLevel
        {   get { return ll_WriteLevel; }
            set { ll_WriteLevel = value; } }
        public static LogLevel ConsoleLevel
        {
            get { return ll_ConsoleLevel; }
            set { ll_ConsoleLevel = value; }
        }

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
        public static void Log(string message, LogLevel level)
        {
            if(level >= ll_ConsoleLevel)
                Console.WriteLine(message);
            if (level >= ll_WriteLevel)
                sw_Writer.WriteLine(message);
        }
    }
}
