using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    internal class ColumnKeeper
    {
        List<long> longs;
        string str_operation;
        public ColumnKeeper()
        {
            longs = new List<long>();
            str_operation = string.Empty;
        }
        public ColumnKeeper(long number,  string operation)
        {
            longs = new List<long>();
            longs.Add(number);
            str_operation = operation;
        }
        public string operation
        {
            get { return str_operation; }
            set { str_operation = value; }
        }
        public void AddNumber(long input)
        {
            longs.Add(input);
        }

        public long GetResult()
        {
            Logger.Log(str_operation + " " + String.Join(", ", longs.ToArray()),LogLevel.Trace);
            if (str_operation == "*")
            {
                long total = 1;
                for (int i = 0; i < longs.Count; i++)
                {
                    total *= longs[i];
                }
                Logger.Log($"Column total: {total}",LogLevel.Trace);
                return total;
            }
            if(str_operation == "+")
            {
                long total = 0;
                for (int i = 0; i < longs.Count; i++)
                {
                    total += longs[i];
                }
                Logger.Log($"Column total: {total}", LogLevel.Trace);
                return total;

            }
            return 0;
        }

    }
}
