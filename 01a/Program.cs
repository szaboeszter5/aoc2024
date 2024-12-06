using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace _01a
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
            Array.Sort(left);
            Array.Sort(right);
            int sum = 0;
            for (int i = 0; i < all.Length; i++)
            {
                sum += Math.Abs(left[i] - right[i]);
            }
        }
    }
}
