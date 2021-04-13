using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputGrid = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day3\input.txt");

            int task1 = FindTreesOnPath(1, 3, inputGrid);
            Console.WriteLine($"Task 1: {task1}");

            List<Tuple<int, int>> values = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1,1),
                new Tuple<int, int>(1,3),
                new Tuple<int, int>(1,5),
                new Tuple<int, int>(1,7),
                new Tuple<int, int>(2,1)
            };

            long task2 = 1;
            int trees;

            values.ForEach(x =>
            {
                trees = FindTreesOnPath(x.Item1, x.Item2, inputGrid);
                task2 = task2 * trees;
            });

            Console.WriteLine($"Task 2: {task2}");

            Console.ReadLine();
        }

        public static int FindTreesOnPath(int columnStep, int rowStep, string[] inputGrid)
        {
            int numberOfTrees = 0;
            int gridWidth = inputGrid[0].Count();
            int index = 0;

            for(int i=0; i<inputGrid.Length; i+=columnStep)
            {
                if (gridWidth < index + 1)
                {
                    index = index - gridWidth;
                }

                if (inputGrid[i][index] == '#')
                {
                    numberOfTrees++;
                }

                index += rowStep;
            }

            return numberOfTrees;
        }
    }
}
