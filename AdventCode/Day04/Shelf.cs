using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public class Shelf
    {
        ShelfSection[] arry_Shelf;
        public Shelf(string input)
        {
            arry_Shelf = new ShelfSection[input.Length];
            for(int i = 0; i < arry_Shelf.Length; i++)
            {
                arry_Shelf[i] = new ShelfSection();
                if (input[i].ToString() == "@")
                {
                    arry_Shelf[i].HasPaper = true;
                }
            }
        }
        public ShelfSection GetSection(int index)
        {
            return arry_Shelf[index];
        }
        public void Remove(int index)
        {
            arry_Shelf[index].HasPaper = false;
        }
        public int Size()
        { return arry_Shelf.Length; }
    }
}
