using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] all = File.ReadAllLines("input.txt");
            int[] left = new int[all.Length];
            int[] right = new int[all.Length];
            for (int i = 0; i < all.Length; i++)
            {
                left[i] = int.Parse(all[i].Split(' ')[0]);
                right[i] = int.Parse(all[i].Split(' ')[3]);
            }

            int sum = 0;
            for (int i = 0; i < left.Length; i++)
            {
                for (int j = 0; j < right.Length; j++) 
                {
                    if (left[i] == right[j])
                    {
                        sum += left[i];
                    }
                }
            }
            ;
        }
    }
}
