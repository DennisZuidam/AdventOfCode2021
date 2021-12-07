using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day02
{
    public class Solution
    {
        public Solution()
        {
            var text = File.ReadAllText("..\\..\\..\\Day02\\input.txt");
            var input = text.Split("\n").ToList();

            Part1(input);
            Part2(input);
        }

        public void Part1(List<string> text)
        {
            var forward = 0;
            var depth = 0;
            var horizontal = 0;

            var totalForward = text.Where(i => i.Contains("forward ")).ToList();
            foreach (var line in totalForward)
            {
                var no = line.Remove(0, 8);
                forward += Int32.Parse(no);
            }

            foreach (var line in text)
            {
                if (line.Contains("down "))
                {
                    var no = int.Parse(line.Remove(0, 5));
                    depth += no;
                }

                if (line.Contains("up "))
                {
                    var no = int.Parse(line.Remove(0, 3));
                    depth -= no;
                }
                if (line.Contains("forward "))
                {
                    var no = line.Remove(0, 8);
                    var forwardNo = Int32.Parse(no);
                    horizontal += forwardNo;
                }
            }

            Console.WriteLine(horizontal * depth);
        }

        public void Part2(List<string> text)
        {
            var forward = 0;
            var depth = 0;
            var aim = 0;
            var horizontal = 0;

            var totalForward = text.Where(i => i.Contains("forward ")).ToList();
            foreach (var line in totalForward)
            {
                var no = line.Remove(0, 8);
                forward += Int32.Parse(no);
            }

            foreach (var line in text)
            {
                if (line.Contains("down "))
                {
                    var no = line.Remove(0, 5);
                    aim += Int32.Parse(no);
                }

                if (line.Contains("up "))
                {
                    var no = line.Remove(0, 3);
                    aim -= Int32.Parse(no);
                }
                if (line.Contains("forward "))
                {
                    var no = line.Remove(0, 8);
                    var forwardNo = Int32.Parse(no);
                    horizontal += forwardNo;
                    if (aim != 0) depth += forwardNo * aim;
                }
            }

            Console.WriteLine(horizontal * depth);
        }
    }


}
