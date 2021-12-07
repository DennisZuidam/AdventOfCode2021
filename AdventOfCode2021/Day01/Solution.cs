using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day01
{
    public class Solution
    {
        public Solution()
        {
            var text = File.ReadAllText("..\\..\\..\\Day01\\input.txt"); 
            var input = text.Split("\n").Select(n => int.Parse(n)).ToList();

            Part1(input);
            Part2(input);
        }



        public static void Part1(List<int> input)
        {
            int totalIncreased = 0;
            int last = 0;

            foreach (int i in input)
            {
                if (last != 0 & i > last) { totalIncreased++; }
                last = i;
            }

            Console.WriteLine($"Totaal increased: {totalIncreased}");
        }

        public static void Part2(List<int> input)
        {
            var numberInList = 0;
            var totalOfThree = 0;
            int totalIncreased = 0;
            int last = 0;

            foreach (int i in input)
            {
                totalOfThree = 0;
                for (int increment = 0; increment < 3; increment++)
                {
                    totalOfThree += input[numberInList];
                    numberInList++;
                }
                if (last != 0 & totalOfThree > last) { totalIncreased++; }
                last = totalOfThree;
                numberInList -= 2;
            }

            Console.WriteLine(totalIncreased);
        }
    }
}
