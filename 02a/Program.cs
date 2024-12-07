using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int sumOfSafe = 0;
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(' ');
                int[] report = new int[line.Length];

                for (int i = 0; i < line.Length; i++)
                {
                    report[i] = int.Parse(line[i]);
                }

                int j = 0;

                if (report.Length == 1)
                {
                    sumOfSafe++;
                }
                else
                {
                    while (j < report.Length - 1 && report[j] < report[j + 1] && Math.Abs(report[j] - report[j + 1]) <= 3 && Math.Abs(report[j] - report[j + 1]) >= 1)
                    {
                        j++;
                    }

                    if (j < report.Length - 1)
                    {
                        j = 0;
                        while (j < report.Length - 1 && report[j] > report[j + 1] && Math.Abs(report[j] - report[j + 1]) <= 3 && Math.Abs(report[j] - report[j + 1]) >= 1)
                        {
                            j++;
                        }
                    }

                    if (j >= report.Length - 1) sumOfSafe++;
                }
            }

        }
    }
}
