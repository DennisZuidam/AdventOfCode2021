using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day08
{
    public class Solution
    {
        public Solution()
        {
            var input = File.ReadAllLines("..\\..\\..\\Day08\\input.txt").ToList();

            Part1(input);
        }

        void Part1(List<string> input)
        {
            var outputValues = new List<string>();
            foreach(var i in input)
            {
                outputValues.Add(i.Substring(i.IndexOf(" | ") + 3));
            }

            Console.WriteLine(SelecttNumbers(outputValues));
        }

        int SelecttNumbers(List<string> input)
        {
            var toCheck = new List<string>();
            var numbers = 0;

            foreach(var line in input)
            {
                var l = line.Split(' ').ToList();
                toCheck.AddRange(l);
            }

            foreach(var l in toCheck)
            {
                if(l.Length == 2 || l.Length == 4 || l.Length == 3 || l.Length == 7)
                {
                    numbers++;
                }
            }

            return numbers;
        }
    }
}
