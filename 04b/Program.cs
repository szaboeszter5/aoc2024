using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04b
{
    internal class Program
    {
        static int width = 0;
        static int height = 0;

        static void Main(string[] args)
        {
            string[] all = File.ReadAllLines("input.txt");
            width = all[0].Length;
            height = all.Length;

            char[,] chars = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chars[i, j] = all[i][j];
                }
            }

            int wordsFound = 0;
            for (int i = 1; i < height-1; i++)
            {
                for (int j = 1; j < width-1; j++)
                {
                    if ((chars[i, j] == 'A') && ((chars[i - 1, j - 1] == 'M' && chars[i + 1, j + 1] == 'S') || (chars[i - 1, j - 1] == 'S' && chars[i + 1, j + 1] == 'M')) && ((chars[i - 1, j + 1] == 'M' && chars[i + 1, j - 1] == 'S') || (chars[i - 1, j + 1] == 'S' && chars[i + 1, j - 1] == 'M')))
                    {
                        wordsFound++;
                    }
                }
            }
        }
    }
}
