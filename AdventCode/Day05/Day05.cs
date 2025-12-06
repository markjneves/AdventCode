using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class Day05
    {
        public static void Run()
        {
            Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day05\\output.txt");
            Logger.WriteLevel = LogLevel.Info;
            Logger.ConsoleLevel = LogLevel.Info;
            string[] input = File.ReadAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day05\\input.txt").Trim().Split("\n");

            List<RangeKeeper> list_Ranges = new List<RangeKeeper>();
            int total = 0;
            foreach (string line in input)
            {
                if (line.Contains("-"))
                {
                    long start = Convert.ToInt64(line.Split('-')[0]);
                    long end = Convert.ToInt64(line.Split('-')[1]);

                    list_Ranges.Add(new RangeKeeper(start, end));
                }
                else if (!String.IsNullOrEmpty(line.Trim()))
                {
                    long test = Convert.ToInt64(line);
                    bool inAnyRange = false;
                    foreach (RangeKeeper range in list_Ranges)
                    {
                        if(range.IsInRange(test))
                        {
                            Logger.Log($"{test} is in range {range.start}-{range.end}",LogLevel.Trace);
                            total++;
                            inAnyRange = true;
                            break;
                        }
                    }
                    if (inAnyRange)
                    {
                        Logger.Log($"{test} is in no range", LogLevel.Trace);

                    }
                }
            }
            Logger.Log($"Part 1 total: {total}",LogLevel.Info);

            for(int i = 0; i < list_Ranges.Count;i++)
            {
                Logger.Log($"Range {list_Ranges[i].start}-{list_Ranges[i].end}", LogLevel.Info);
                for (int j = 0; j < list_Ranges.Count; j++)
                {
                    if (i == j)
                        continue;
                    if (list_Ranges[j].IsInRange(list_Ranges[i].start))
                    {
                        list_Ranges[i].start = list_Ranges[j].end +1;
                    }
                    if (list_Ranges[j].IsInRange(list_Ranges[i].end))
                    {
                        list_Ranges[i].end = list_Ranges[j].start - 1;
                    }
                }
                Logger.Log($"New range {list_Ranges[i].start}-{list_Ranges[i].end}", LogLevel.Info);
            }
            long long_total2 = 0;
            foreach (RangeKeeper range in list_Ranges)
            {
                Logger.Log($"Range {range.start}-{range.end}", LogLevel.Info);
                if(range.IsValidRange())
                {
                    long temp = range.end - range.start + 1;
                    Logger.Log($"Is valid. Add {temp}", LogLevel.Info);
                    long_total2 += temp;
                }
                else
                {
                    Logger.Log("Is not valid",LogLevel.Info);
                }
            }
            Logger.Log($"Part 2 total: {long_total2}", LogLevel.Info);

        }
    }
}
