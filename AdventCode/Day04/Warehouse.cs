using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public class Warehouse
    {
        Shelf[] arry_Shelves;
        public Warehouse(string input) 
        {
            input = input.Trim();
            string[] arry_input = input.Split('\n');
            arry_Shelves = new Shelf[arry_input.Length];
            for (int i = 0; i < arry_input.Length; i++)
            {
                arry_Shelves[i] = new Shelf(arry_input[i].Trim());
            }
        }
        public void CalcNeighbors()
        {
            for(int i = 0; i < arry_Shelves.Length; i++)
            {
                for (int j = 0; j < arry_Shelves[i].Size(); j++)
                {
                    arry_Shelves[i].GetSection(j).Neighbors = 0;
                }
            }
            for(int i = 0; i < arry_Shelves.Length; i++)
            {
                for (int j = 0; j < arry_Shelves[i].Size(); j++)
                {
                    if (arry_Shelves[i].GetSection(j).HasPaper)
                    {
                        for (int row = i - 1; row <= i + 1; row++)
                        {
                            for(int col = j - 1; col <= j + 1; col++)
                            {
                                if (row >= 0 && row < arry_Shelves.Length)
                                {
                                    if (col >= 0 && col < arry_Shelves[i].Size())
                                    {
                                        if(row != i || col != j)
                                        {
                                            arry_Shelves[row].GetSection(col).Neighbors++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PrintNeightbors()
        {
            for (int i = 0; i < arry_Shelves.Length; i++)
            {
                string str_Shelf = "";
                for ( int j = 0; j < arry_Shelves[i].Size(); j++)
                {
                    
                    if (arry_Shelves[i].GetSection(j).HasPaper)
                    {
                        str_Shelf += arry_Shelves[i].GetSection(j).Neighbors.ToString();
                    }
                    else
                    {
                        str_Shelf += ".";

                    }
                }
                Logger.Log(str_Shelf,LogLevel.Info);
            }
        }

        public void RemoveItems()
        {
            for (int i = 0; i < arry_Shelves.Length; i++)
            {
                for(int j = 0; j < arry_Shelves[i].Size(); j++)
                {
                    if (arry_Shelves[i].GetSection(j).HasPaper && arry_Shelves[i].GetSection(j).Neighbors < 4)
                    {
                        arry_Shelves[i].Remove(j);
                        /*                        for (int row = i - 1; row <= i + 1; row++)
                                                {
                                                    for (int col = j - 1; col <= j + 1; col++)
                                                    {
                                                        if (row >= 0 && row < arry_Shelves.Length)
                                                        {
                                                            if (col >= 0 && col < arry_Shelves[i].Size())
                                                            {
                                                                if (row != i || col != j)
                                                                {
                                                                    arry_Shelves[row].GetSection(col).Neighbors--;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }*/
                    }
                }
            }
        }
        public int GetTotalRemoveable()
        {
            int total = 0;
            for(int i = 0; i < arry_Shelves.Length; i++)
            {
                for( int j = 0; j < arry_Shelves[i] .Size(); j++)
                {
                    if (arry_Shelves[i].GetSection(j).HasPaper && arry_Shelves[i].GetSection(j).Neighbors < 4)
                    {
                        total++;
                    }
                }
            }
            return total;
        }
    }
}
