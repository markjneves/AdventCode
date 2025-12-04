using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class Day04
    {
        public static void Run()
        {
            Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day04\\output.txt");
            Logger.WriteLevel = LogLevel.Info;
            Logger.ConsoleLevel = LogLevel.Info;
            string input = File.ReadAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day04\\input.txt");

            Warehouse wh = new Warehouse(input);
            wh.CalcNeighbors();
            wh.PrintNeightbors();
            int total = wh.GetTotalRemoveable();
            Logger.Log("Part 1 Total: " + total.ToString(),LogLevel.Info);
            int final_total = total;
            do
            {
                wh.RemoveItems();
                wh.CalcNeighbors();
                wh.PrintNeightbors();
                Logger.Log("----------------------------------------------------------", LogLevel.Info);
                total = wh.GetTotalRemoveable();
                final_total += total;
            } while (total != 0);

            Logger.Log("Part 2 Total: " + final_total.ToString(), LogLevel.Info);

        }
    }
}
