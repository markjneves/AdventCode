using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventCode
{
    public static class Day06
    {
        public static void Run()
        {
            Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day06\\output.txt");
            //Logger.WriteLevel = LogLevel.Info;
            //Logger.ConsoleLevel = LogLevel.Info;
            string input = File.ReadAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day06\\input.txt");


            List<ColumnKeeper> ck = new List<ColumnKeeper>();
            string[] rows = input.Split("\n");
            long total = 0;
            foreach (string row in rows)
            {
                string[] cols = Regex.Split(row.Trim(), "\\s+");
                if (ck.Count <  cols.Length)
                {
                    foreach (string col in cols)
                    {
                        ck.Add(new ColumnKeeper());
                    }
                }
                if (cols[0] == "+" || cols[0] == "*")
                {
                    for(int i  = 0; i < cols.Length; i++)
                    {
                        ck[i].operation = cols[i];
                        total += ck[i].GetResult();
                    }
                }
                else if (Regex.IsMatch(cols[0],"\\d+"))
                {
                    for (int i = 0; i < cols.Length; i++)
                    {
                        ck[i].AddNumber(Convert.ToInt64(cols[i]));
                    }
                }
            }
            Logger.Log($"Part 1 total: {total}",LogLevel.Info);
            total = 0;
            ck = new List<ColumnKeeper>();
            int keeper_index = 0;
            for (int col = 0; col < rows[0].Length; col++)
            {
                string number = "";
                string str_operator = "";
                foreach (string row in rows)
                {
                    if (row.Length > 0)
                    {
                        if (Regex.IsMatch(row[col].ToString(), "\\d"))
                            number += row[col];
                        else if (Regex.IsMatch(row[col].ToString(), "[+*]"))
                        {
                            str_operator += row[col].ToString();
                        }
                    }
                }
                if(string.IsNullOrEmpty(number) && string.IsNullOrEmpty(str_operator))
                {
                    keeper_index++;
                    continue;
                }
                if(keeper_index == ck.Count)
                {
                    ck.Add(new ColumnKeeper(Convert.ToInt64(number),str_operator));
                }
                else
                {
                    ck[keeper_index].AddNumber(Convert.ToInt64(number));
                }
            }
            foreach (ColumnKeeper keeper in ck)
            {
                total += keeper.GetResult();
            }
            Logger.Log($"Part 2 total: {total}", LogLevel.Info);

        }
    }
}
