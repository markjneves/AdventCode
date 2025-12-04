using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public class ShelfSection
    {
        bool bool_HasPaper = false;
        int int_Neighbors = 0;
        public bool HasPaper
            { get { return bool_HasPaper; } set { bool_HasPaper = value; } }
        public int Neighbors
            { get { return int_Neighbors; } set { int_Neighbors = value; } }
    }
}
