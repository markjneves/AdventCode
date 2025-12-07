using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    internal class TreeHandler
    {
        string[] arry_string_layout;
        internal TreeHandler(string input)
        {
            arry_string_layout = input.Trim().Split("\n");
        }

        private int ProcessLine(int line)
        {
            StringBuilder sb = new StringBuilder(arry_string_layout[line]);
            int line_total = 0;
            for(int i = 0; i < arry_string_layout[line-1].Length;i++)
            {
                if (arry_string_layout[line - 1][i] == 'S')
                {
                    sb[i] = '|';
                }
                else if (arry_string_layout[line - 1][i] == '|')
                {
                    if (sb[i]=='.')
                    {
                        sb[i] = '|';
                    }
                    else if (sb[i] ==  '^')
                    {
                        line_total++;
                        if(i - 1 >= 0)
                            sb[i - 1] = '|';
                        if(i + 1 <= sb.Length)
                            sb[i + 1] = '|';
                    }
                }
            }
            arry_string_layout[line] = sb.ToString();
            return line_total;
        }
        private int ProcessLineTimeline()
        {
            return arry_string_layout[0].IndexOf('S');
        }
        private List<long> ProcessLineTimeline(int line, List<long> timeline_input)
        {
            List<long> output = Enumerable.Repeat(Convert.ToInt64(0),timeline_input.Count).ToList();
            for (int i = 0; i < arry_string_layout[line].Length; i++)
            {
                if (arry_string_layout[line][i] == '^')
                { 
                    output[i - 1] += timeline_input[i];
                    output[i + 1] += timeline_input[i];
                }
                else
                {
                    output[i] += timeline_input[i];
                }
            }
            long line_total = 0;
            foreach (long i in output)
            {
                line_total += i;
            }
            Logger.Log($"Line: {line} - Total: {line_total}",LogLevel.Trace);
            Logger.Log(string.Join(",",output),LogLevel.Trace);
            return output;
        }
        internal int ProcessTree()
        {
            int total = 0;
            for (int i = 1; i < arry_string_layout.Length; i++)
            {
                total += ProcessLine(i);
            }
            return total;
        }
        internal long ProcessTreeTimeline()
        {
            List<long> timeline = Enumerable.Repeat(Convert.ToInt64(0),arry_string_layout[0].Length).ToList();
            timeline[ProcessLineTimeline()] = 1;
            for (int i = 1; i < arry_string_layout.Length; i++)
            {
                timeline = ProcessLineTimeline(i,timeline);
            }
            long total = 0;
            foreach(long i in timeline)
            {
                total += i;
            }
            return total;
        }
    }
}
