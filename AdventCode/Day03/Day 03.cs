using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class Day03
    {
        public static void Run()
        {
            Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day03\\output.txt");
            //Logger.WriteLevel = LogLevel.Info;
            //Logger.ConsoleLevel = LogLevel.Info;
            string[] input = File.ReadAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day03\\test_input.txt").Split('\n');

            foreach (string line in input)
            {
                BankChecker.NewCheckBank(line.Trim());
            }

            Logger.ConsoleLog("Total: " + BankChecker.NewBankTotal.ToString());
        }
    }
}
