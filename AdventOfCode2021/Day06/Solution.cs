using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day06
{
    public class Solution
    {
        public Solution()
        {
            var input = File.ReadAllText(@"..\\..\\..\\Day06\\input.txt").Split(',').Select(x => int.Parse(x)).ToList();

            Part1(input);
        }

        public void Part1(List<int> input)
        {
            for (int i = 0; i < 80; i++)
            {
                var newList = new List<int>();
                for (int j = 0; j < input.Count; j++)
                {

                    if (input[j] == 0)
                    {
                        input[j] = 7;
                        newList.Add(8);
                    }

                    input[j]--;
                }

                var l = new List<int>();
                l.AddRange(input);
                l.AddRange(newList);
                input = l; 
            }
            Console.WriteLine(input.Count);
        }
    }
}
