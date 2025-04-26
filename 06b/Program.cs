using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _06b
{
    class Position
    {
        public int X;
        public int Y;
        public int Direction; // 1-up 2-right 3-down 4-left
    }

    internal class Program
    {
        static int width;
        static int height;

        static void Main(string[] args)
        {
            string[] map = File.ReadAllLines("input.txt");

            width = map[0].Length;
            height = map.Length;
            
            Position start = new Position();
            Position guard;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i][j] == '^')
                    {
                        start.X = i;
                        start.Y = j;
                        start.Direction = 1;
                    }
                }
            }

            bool inloop;
            int numOfLoops = 0;
            List<Position> path;
            char[,] addedObstruction;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i][j] != '#' && map[i][j] != '^')
                    {
                        addedObstruction = new char[height,width];
                        for (int a = 0; a < height; a++)
                        {
                            for (int b = 0; b < width; b++)
                            {
                                addedObstruction[a, b] = map[a][b];
                            }
                        }
                        addedObstruction[i,j] = '#';

                        guard = new Position()
                        {
                            X = start.X,
                            Y = start.Y,
                            Direction = start.Direction
                        };

                        inloop = false;

                        path = new List<Position>
                        {
                            new Position()
                            {
                                X = start.X,
                                Y = start.Y,
                                Direction = start.Direction
                            }
                        };

                        while (!inloop && guard.X > 0 && guard.Y > 0 && guard.X < height - 1 && guard.Y < width - 1)
                        {
                            switch (guard.Direction)
                            {
                                case 1:
                                    if (addedObstruction[guard.X - 1, guard.Y] == '#') guard.Direction = 2;
                                    else guard.X--;
                                    break;
                                case 2:
                                    if (addedObstruction[guard.X,guard.Y + 1] == '#') guard.Direction = 3;
                                    else guard.Y++;
                                    break;
                                case 3:
                                    if (addedObstruction[guard.X + 1, guard.Y] == '#') guard.Direction = 4;
                                    else guard.X++;
                                    break;
                                case 4:
                                    if (addedObstruction[guard.X, guard.Y - 1] == '#') guard.Direction = 1;
                                    else guard.Y--;
                                    break;
                            }

                            if (path.Exists(x => x.X == guard.X && x.Y == guard.Y && x.Direction == guard.Direction))
                            {
                                inloop = true;
                            }
                            else
                            {
                                path.Add(new Position()
                                {
                                    X = guard.X,
                                    Y = guard.Y,
                                    Direction = guard.Direction
                                });
                            }
                        }
                        if (inloop)
                        {
                            numOfLoops++;
                        }
                    }
                }
            }
        }
    }
}
