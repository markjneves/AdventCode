using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public class LockCodeHandler
    {
        private int int_Digit;
        private List<int> arry_int_digit_counter;
        private static int int_Digit_Max = 100;
        private int int_Zero_Counter = 0;
        public LockCodeHandler()
        {
            int_Digit = 50;
            arry_int_digit_counter = Enumerable.Repeat(0,int_Digit_Max).ToList();
            arry_int_digit_counter[int_Digit]++;
        }
        public LockCodeHandler(int intDigit)
        {
            int_Digit = intDigit;
            arry_int_digit_counter = Enumerable.Repeat(0, int_Digit_Max).ToList();
            arry_int_digit_counter[int_Digit]++;
        }

        public int GetDigit()
        {
            return int_Digit;
        }
        private int ZeroPasses (int start, int end)
        {

            int int_ZeroPasses = Math.Abs(end) / int_Digit_Max;

            if (start > 0 && end < 0)
                int_ZeroPasses++;
            else if (end == 0)
                int_ZeroPasses++;

            //int int_ZeroPasses = 0;
            //while (end < 0)
            //{
            //    end += int_Digit_Max;
            //    int_ZeroPasses++;
            //}
            //if (int_ZeroPasses > 0 && start == 0)
            //{
            //    int_ZeroPasses--;
            //}
            //if (end == 0)
            //    int_ZeroPasses++;

            //while (end >= int_Digit_Max)
            //{
            //    end -= int_Digit_Max;
            //    int_ZeroPasses++;
            //}

            return int_ZeroPasses;
        }
        public void Rotate(string str_Rotation)
        {
            int int_OldDigit = int_Digit;
            int int_NewDigit;
            if (str_Rotation.ToUpper().StartsWith("L"))
            {
                int_NewDigit = int_Digit - Convert.ToInt32(str_Rotation.Substring(1));
            }
            else
            {
                int_NewDigit = int_Digit + Convert.ToInt32(str_Rotation.Substring(1));
            }
            int_Zero_Counter += ZeroPasses(int_OldDigit, int_NewDigit);


            int_Digit = (int_NewDigit % int_Digit_Max + int_Digit_Max) % int_Digit_Max;
            arry_int_digit_counter[int_Digit]++;
        }
        public int GetCounter (int index)
        {
            return arry_int_digit_counter[index];
        }
        public int GetZeroCounter()
        {
            return int_Zero_Counter;
        }
    }
}
