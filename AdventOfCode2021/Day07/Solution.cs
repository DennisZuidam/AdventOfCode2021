using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day07
{
    public class Solution
    {
        public Solution()
        {
            var input = File.ReadAllText("..\\..\\..\\Day07\\input.txt").Split(",").Select(n => int.Parse(n)).ToArray();

            Part1(input);
        }

        public void Part1(int[] input)
        {
            var fuel = 0;

            var max = input.Max();
            var results = new int[max];
            for(var i = 0; i < max; i++)
            {
                var result = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    result += Math.Abs(input[j] - i);
                }

                results[i] = result;
            }

            fuel = results.Where(r => r != 0).Min();

            Console.WriteLine(fuel);
        }
    }
}
