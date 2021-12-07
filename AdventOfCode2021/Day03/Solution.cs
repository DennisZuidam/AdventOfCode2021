using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day03
{
    public class Solution
    {
        public Solution()
        {
            var input = File.ReadAllLines("..\\..\\..\\Day03\\input.txt").ToList();

            Part1(input);
            Part2(input);
        }

        public void Part1(List<string> input)
        {
            string gammaNumbers = "";
            string epsilonNumbers = "";

            for (var i = 0; i < input[0].Length; i++)
            {
                var zeros = 0;
                var ones = 1;

                foreach (var l in input)
                {
                    if (l[i] == '0') zeros++;
                    if (l[i] == '1') ones++;
                }

                if (zeros > ones) gammaNumbers += "0";
                else gammaNumbers += "1";
            }


            foreach (var no in gammaNumbers)
            {
                if (no == '0')
                {
                    epsilonNumbers += "1";
                }
                else
                {
                    epsilonNumbers += "0";
                }
            }

            var gamma = Convert.ToInt32(gammaNumbers, 2);
            var epsilon = Convert.ToInt32(epsilonNumbers, 2);

            Console.WriteLine(gamma * epsilon);
        }

        public void Part2(List<string> input)
        {
            var oxygen = getValue(false, input);
            var co2 = getValue(true, input);
            Console.WriteLine(oxygen * co2);
        }

        private int getValue(bool leastCommon, List<string> input)
        {
            var data = input.ToList();
            for (var i = 0; i < input[0].Length; ++i)
            {
                var zeros = 0L;
                var ones = 0L;

                foreach (var l in data)
                    if (l[i] == '0')
                        zeros++;
                    else
                        ones++;

                if ((leastCommon && ones >= zeros) || (!leastCommon && zeros > ones))
                {
                    for (var j = data.Count - 1; j >= 0; j--)
                        if (data[j][i] == '1')
                            data.RemoveAt(j);
                }
                else
                {
                    for (var j = data.Count - 1; j >= 0; j--)
                        if (data[j][i] == '0')
                            data.RemoveAt(j);
                }

                if (data.Count == 1)
                    break;
            }

            var result = 0;
            foreach (var ch in data[0])
            {
                result *= 2;
                if (ch == '1')
                    result++;
            }

            return result;
        }
    }
}
