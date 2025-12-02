using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class ID_Checker
    {
        private static List<long> list_int_InvalidIDs = new List<long>();
        private static long int_Invalid_Total = 0;

        public static List<long> InvalidList
            { get { return list_int_InvalidIDs; } }
        public static long InvalidTotal
            { get { return int_Invalid_Total; } }

        public static void IDRange(string input)
        {
            long start = Convert.ToInt64(input.Split("-")[0]);
            long end = Convert.ToInt64(input.Split("-")[1]);
            List<long> list = new List<long>();
            Logger.ConsoleLog("Range: " + input);
            
            for (long i = start; i <= end; i++)
            {
                if(NewTestRepeatID(i))
                {
                    list.Add(i);
                    int_Invalid_Total += i;
                }
            }
            Logger.ConsoleLog("Invalid Numbers: " + String.Join(',', list));
            Logger.ConsoleLog("");
            list_int_InvalidIDs.AddRange(list);
        }

        private static bool TestRepeatID(long ID)
        {
            string str_ID = ID.ToString();
            return str_ID.Substring(0, str_ID.Length / 2) == str_ID.Substring(str_ID.Length / 2);
        }
        private static bool NewTestRepeatID(long ID)
        {
            string str_ID = ID.ToString();

            for (int i = 1; i <= str_ID.Length / 2; i++)
            {
                string test = string.Join("", Enumerable.Repeat<string>(str_ID.Substring(0, i), str_ID.Length / i));
                if (str_ID == test)
                    return true;
            }
            return false;
        }

    }
}
