using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> rules = [];

            FileStream fs = File.OpenRead("input.txt");
            StreamReader sr = new(fs);
            string[] line;

            while (sr.Peek() != '\r')
            {
                line = sr.ReadLine().Split('|');

                if (!rules.ContainsKey(line[0]))
                {
                    rules.Add(line[0], []);
                }

                rules[line[0]].Add(line[1]);
            }

            int sum = 0; //of the middle page numbers from incorrectly-ordered updates
            
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine().Split(',');

                int i = 0;
                while (i < line.Length - 1 && rules[line[i]].Contains(line[i + 1]))
                {
                    i++;
                }

                if (i < line.Length - 1) // then its not in order
                {
                    for (i = 0; i < line.Length; i++) 
                    {
                        for (int j = 0; j < line.Length-1; j++)
                        {
                            if (rules.ContainsKey(line[j]) && !rules[line[j]].Contains(line[j+1]))
                            {
                                (line[j], line[j+1]) = (line[j+1], line[j]);
                            }
                        }
                    }
                    sum += int.Parse(line[(int)Math.Floor((double)line.Length / 2)]);
                }
            }
        }
    }
}
