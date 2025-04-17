using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,List<string>> rules = new SortedDictionary<string,List<string>>();

            FileStream fs = File.OpenRead("input.txt");
            StreamReader sr = new StreamReader(fs);
            string[] line;

            while (sr.Peek() != '\r')
            {
                line = sr.ReadLine().Split('|');

                if (!rules.ContainsKey(line[0]))
                {
                    rules.Add(line[0], new List<string>());
                }

                rules[line[0]].Add(line[1]);
            }

            int sum = 0; //of the middle page numbers from correctly-ordered updates

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine().Split(',');

                int i = 0;
                while (i < line.Length-1 && rules[line[i]].Contains(line[i+1])) 
                {
                    i++;
                }
                if (i >= line.Length-1)
                {
                    sum += int.Parse(line[(int)Math.Floor((double)line.Length/2)]);
                }
            }
        }
    }
}
