using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02b
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

                bool error = false;
                int[] reportCopy = new int[report.Length - 1];
                int e = -1;


                int j = 0;

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

                if (j >= report.Length - 1)
                {
                    sumOfSafe++;
                }
                else
                {
                    error = true;
                    while (e < report.Length && error)
                    {
                        e++;
                        j = 0;
                        for (int i = 0; i < reportCopy.Length; i++)
                        {
                            if (j == e) j++;
                            reportCopy[i] = report[j];
                            j++;
                        }

                        j = 0;

                        while (j < reportCopy.Length - 1 && reportCopy[j] < reportCopy[j + 1] && Math.Abs(reportCopy[j] - reportCopy[j + 1]) <= 3 && Math.Abs(reportCopy[j] - reportCopy[j + 1]) >= 1)
                        {
                            j++;
                        }

                        if (j < reportCopy.Length - 1)
                        {
                            j = 0;
                            while (j < reportCopy.Length - 1 && reportCopy[j] > reportCopy[j + 1] && Math.Abs(reportCopy[j] - reportCopy[j + 1]) <= 3 && Math.Abs(reportCopy[j] - reportCopy[j + 1]) >= 1)
                            {
                                j++;
                            }
                        }

                        if (j >= reportCopy.Length - 1)
                        {
                            sumOfSafe++;
                            error = false;
                        }

                    }
                }
            }
        }
    }
}
