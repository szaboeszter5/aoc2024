using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _08a
{
    class Coordinate
    {
        public int x, y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] all = File.ReadAllLines("input.txt");
            int width = all[0].Length;
            int height = all.Length;

            char[,] map = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = all[i][j];
                }
            }

            Dictionary<char,List<Coordinate>> antennas = new Dictionary<char,List<Coordinate>>();
            List<Coordinate> antinodes = new List<Coordinate>();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (Antenna(map[i, j]))
                    { 
                        if (!antennas.ContainsKey(map[i, j])) antennas.Add(map[i,j], new List<Coordinate>() { new Coordinate(i,j)});
                        else antennas[map[i, j]].Add(new Coordinate(i, j));
                    }
                }
            }

            for (int i = 0;i < antennas.Keys.Count; i++)
            {
                char key = antennas.Keys.ElementAt(i);

                for(int j = 0;j < antennas[key].Count-1; j++)
                {
                    for (int k = j+1; k < antennas[key].Count; k++)
                    {
                        Coordinate a = antennas[key][j];
                        Coordinate b = antennas[key][k];
                        Coordinate v = new Coordinate(b.x - a.x, b.y - a.y);

                        Coordinate antinode = new Coordinate(b.x + v.x, b.y + v.y);
                        if(!antinodes.Exists(t=>t.x == antinode.x && t.y == antinode.y) && IsOnMap(antinode, height,width)) antinodes.Add(antinode);

                        antinode = new Coordinate(a.x - v.x, a.y - v.y);
                        if (!antinodes.Exists(t => t.x == antinode.x && t.y == antinode.y) && IsOnMap(antinode, height, width)) antinodes.Add(antinode);
                    }
                }
            }
        }

        private static bool IsOnMap(Coordinate antinode, int height, int width)
        {
            return antinode.x >= 0 && antinode.x < height && antinode.y >= 0 && antinode.y < width;
        }

        private static bool Antenna(char value)
        {
            return (value >= 48 && value <= 57) || (value >= 65 && value <= 90) || (value >= 97 && value <= 122);
        }
    }
}
