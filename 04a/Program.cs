using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _04a
{
    internal class Program
    {
        static string word = "XMAS";
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
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (chars[i, j] == 'X')
                    {
                        //up
                        int x = i, y = j, k = 0;
                        while (x >= 0 && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            x--;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++;
                        }
                        
                        //upright
                        x = i; y = j; k = 0;
                        while (x >= 0 && y < width && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            x--;
                            y++;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++;
                        }
                        
                        //right
                        x = i; y = j; k = 0;
                        while (y < width && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            y++;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++;
                        }
                        
                        //downright
                        x = i; y = j; k = 0;
                        while (x < height && y < width && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            x++;
                            y++;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++;
                        }

                        //down
                        x = i; y = j; k = 0;
                        while (x < height && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            x++;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++; 
                        }

                        //downleft
                        x = i; y = j; k = 0;
                        while (x < height && y >= 0 && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            x++;
                            y--;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++; 
                        }

                        //left
                        x = i; y = j; k = 0;
                        while (y >= 0 && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            y--;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++;
                        }

                        //upleft
                        x = i; y = j; k = 0;
                        while (x >= 0 && y >= 0 && k < word.Length && word[k] == chars[x, y])
                        {
                            k++;
                            x--;
                            y--;
                        }
                        if (k >= word.Length)
                        {
                            wordsFound++;
                        }
                    }
                }
            }
        }
    }
}
