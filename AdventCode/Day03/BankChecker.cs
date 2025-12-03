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

        public static int NewCheckBank(string input)
        {
            Logger.Log("Line: " + input, LogLevel.Info);
            List<int> max_list = Enumerable.Repeat<int>(0,12).ToList();
            int max_index = 0;
            for (int i = 0; i < max_list.Count; i++)
            {
                for(int j = max_index; j <= input.Length - max_list.Count + i; j++)
                {
                    int test_value = Convert.ToInt32("0" + input[j]);
                    if (test_value > max_list[i])
                    {
                        Logger.Log(test_value.ToString() + " > " + max_list[i].ToString(), LogLevel.Trace);
                        max_index = j+1;
                        max_list[i] = test_value;
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
