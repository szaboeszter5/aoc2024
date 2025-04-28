using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07a
{
    internal class Program
    {
        static UInt64 result = 0;
        static bool equation = false;

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            UInt64 sum = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                equation = false;
                string[] line = lines[i].Replace(":", "").Split(' ');
                result = Convert.ToUInt64(line[0]);

                Solve(line, 1, Convert.ToUInt64(line[1]));
                if (equation) sum += result;
            }
        }
        static void Solve(string[] tree, int level, UInt64 root)
        {
            if (level == tree.Length - 1 && root == result) equation = true;

            if (level < tree.Length - 1)
            {
                Solve(tree, level+1, root + Convert.ToUInt64(tree[level+1]));
            }

            if (level < tree.Length - 1)
            {
                Solve(tree, level+1, root * Convert.ToUInt64(tree[level+1]));
            }

            return;
        }
    }
}
 