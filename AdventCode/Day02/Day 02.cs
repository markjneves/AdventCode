using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class Day02
    {
        public static void Run()
        {
            Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day02\\output.txt");
            string[] input = File.ReadAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day02\\input.txt").Split(',');

            foreach (string line in input)
            {
                ID_Checker.IDRange(line);
            }

            Logger.ConsoleLog("Total: " + ID_Checker.InvalidTotal);
        }
    }
}
