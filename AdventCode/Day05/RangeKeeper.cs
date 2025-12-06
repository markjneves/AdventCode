using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    internal class RangeKeeper
    {
        private long long_start;
        private long long_end;
        public RangeKeeper(long start, long end)
        {
            long_start = start;
            long_end = end;
        }
        public long start
            { 
            get { return long_start; }
            set { long_start = value; }
        }
        public long end
        {
            get { return long_end; }
            set { long_end = value; }
        }
        public bool IsInRange(long input)
        {
            return (input >= long_start && input <= long_end);
        }
        public bool IsValidRange()
        {
            return long_start <= long_end;
        }
    }
}
