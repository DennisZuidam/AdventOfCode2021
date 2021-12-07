using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04
{
    public class Solution
    {
        public Solution()
        {
            var input = File.ReadAllLines("..\\..\\..\\Day04\\input.txt").Where(s => !string.IsNullOrEmpty(s)).ToArray();
            var bingoNumbers = input[0].Split(',').Select(i => int.Parse(i)).ToList();

            Part1and2(input, bingoNumbers);
        }

        public void Part1and2(string[] input, List<int> bingoNumbers)
        {
            var boards = new List<BingoBoard>();
            var id = 1;

            while (id < input.Length)
            {
                boards.Add(new BingoBoard(input, id));
                id += 5;
            }

            foreach (var number in bingoNumbers)
            {
                for (var i = boards.Count - 1; i >= 0; i--)
                {
                    boards[i].SelectNo(number);
                    if (boards[i].Winner())
                    {
                        Console.WriteLine(boards[i].SumUpUnCalled() * number);
                        boards.RemoveAt(i);
                    }
                }
            }
        }

        class BingoBoard
        {
            int[,] numbers = new int[5, 5];

            public BingoBoard(string[] lines, int index)
            {
                for (var i = 0; i < 5; i++)
                {
                    var numberLines = lines[index + i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (var j = 0; j < 5; j++)
                    {
                        numbers[i, j] = int.Parse(numberLines[j]);
                    }
                }
            }

            public void SelectNo(int number)
            {
                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        if (numbers[i, j] == number)
                            numbers[i, j] = -1;
                    }
                }
            }

            public bool Winner()
            {
                for (var i = 0; i < 5; i++)
                {
                    if (numbers[i, 0] + numbers[i, 1] + numbers[i, 2] + numbers[i, 3] + numbers[i, 4] == -5) 
                        return true;
                    if (numbers[0, i] + numbers[1, i] + numbers[2, i] + numbers[3, i] + numbers[4, i] == -5) 
                        return true;
                }
                return false;
            }

            public int SumUpUnCalled()
            {
                var total = 0;

                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        if (numbers[i, j] != -1) { total += numbers[i, j]; }
                    }
                }

                return total;
            }
        }
    }

    


}
