using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class Day07
    {
        public static void Run()
        {
            Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day07\\output.txt");
            //Logger.WriteLevel = LogLevel.Info;
            //Logger.ConsoleLevel = LogLevel.Info;
            string input = File.ReadAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day07\\input.txt");
            TreeHandler th = new TreeHandler(input);
            int total = th.ProcessTree();
            Logger.Log($"Part 1 Total: {total.ToString()}", LogLevel.Info);
            Logger.Log($"Part 2 Total: {th.ProcessTreeTimeline().ToString()}",LogLevel.Info);
        }
    }
}
