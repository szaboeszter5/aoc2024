using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _03a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string all = File.ReadAllText("input.txt").Replace("\n","").Replace("\r","");
            all = Regex.Replace(all, "(don't\\(\\)).*?(?=do\\(\\)|don't\\(\\)|$)", "");
            
            Regex rg = new Regex(@"(mul)\(\d{1,3},\d{1,3}\)");
            MatchCollection matched_muls = rg.Matches(all);

            List<string[]> numbers = new List<string[]>();
            foreach (Match match in matched_muls)
            {
                numbers.Add(match.Value.Replace("mul(", "").Replace(")", "").Split(','));
            }

            int sum = 0;
            foreach (string[] numberArray in numbers)
            {
                sum = sum + (int.Parse(numberArray[0]) * int.Parse(numberArray[1]));
            }
        }
    }
}
