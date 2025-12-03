using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class BankChecker
    {
        private static long long_BankTotal = 0;
        private static long new_long_BankTotal = 0;

        public static long BankTotal
        {  get { return long_BankTotal; } }
        public static long NewBankTotal
        { get { return new_long_BankTotal; } }
        public static int CheckBank(string input)
        {
            Logger.Log("Line: " + input, LogLevel.Info);
            int first = 0;
            int second = 0;

            for (int i = 0; i < (input.Length); i++)
            {
                int test_digit = Convert.ToInt32("0" + input[i]);
                if (test_digit > first && i < input.Length - 1)
                {
                    first = test_digit;
                    second = Convert.ToInt32("0" + input[i+1]);
                }
                else if( test_digit > second)
                {
                    second = test_digit;
                }
            }
            int line_total = (first * 10) + second;
            Logger.Log("Line total: " + line_total.ToString(),LogLevel.Info);
            long_BankTotal += line_total;
            return 0;
        }
        private static List<int> set_list(List<int> list, string str_input, int start)
        {
            List<int> new_list = new List<int>();
            for (int i = 0; i < start; i++)
            {
                new_list.Add(list[i]);
            }
            for(int i = 0; new_list.Count < 12; i++)
            {
                new_list.Add(Convert.ToInt32("0" + str_input[i]));
            }
            Logger.Log("New Max: " + String.Join("",new_list), LogLevel.Trace);

            return new_list;
        }
        public static int NewCheckBank(string input)
        {
            Logger.Log("Line: " + input, LogLevel.Info);
            List<int> max_list = Enumerable.Repeat<int>(0,12).ToList();
            for (int i = 0; i < input.Length - 12; i++)
            {
                int test_int = Convert.ToInt32("0" + input[i]);
                for(int j = 0; j < max_list.Count; j++)
                {
                    if (test_int > max_list[j] && i < (input.Length - 12 + j))
                    {
                        max_list = set_list(max_list,input.Substring(i),j);
                        break;
                    }
                }
            }
            long line_max = Convert.ToInt64(String.Join("", max_list));
            Logger.Log("Final Max: " + line_max.ToString(),LogLevel.Info);
            new_long_BankTotal += line_max;
            return 0;
        }
    }
}
