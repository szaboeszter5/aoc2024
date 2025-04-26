using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06a
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

            int a = 0, b = 0;
            int sum = 1;

            char[,] map = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = all[i][j];

                    if (map[i, j] == '^')
                    {
                        a = i; 
                        b = j;
                    }
                }
            }

            while (a > 0)
            {
                if (map[a - 1, b] == '#')
                {
                    Rotate(ref map, ref a, ref b);
                }

                map[a, b] = 'X';
                a--;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j] == 'X')
                    {
                        sum++;
                    }
                }
            }
        }

        static void Rotate(ref char[,] map, ref int a, ref int b)
        {
            char[,] newMap = new char[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    newMap[i, j] = map[j,height -1 -i];
                }
            }
            map = newMap;
            (a, b) = (height - b - 1, a);            
        }
    }
}
