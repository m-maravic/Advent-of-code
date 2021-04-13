using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = GetInput(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day1\input.txt");

            Console.WriteLine("First part: " + FindSumOfTwo(inputNumbers));
            Console.WriteLine("Second part: " + FindSumOfThree(inputNumbers));

            Console.ReadLine();
        }

        public static List<int> GetInput(string filePath)
        {
            List<int> inputNumbers = new List<int>();
            string line;

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    inputNumbers.Add(Int32.Parse(line));
                }
                file.Close();
            }

            return inputNumbers;
        }

        public static int FindSumOfTwo(List<int> inputNumbers)
        {
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                for (int j = 1; j < inputNumbers.Count - 1; j++)
                {
                    if (inputNumbers[i] + inputNumbers[j] == 2020)
                    {
                        return inputNumbers[i] * inputNumbers[j];
                    }
                }
            }

            return -1;
        }

        public static int FindSumOfThree(List<int> inputNumbers)
        {
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                for (int j = 1; j < inputNumbers.Count - 1; j++)
                {
                    for (int k = 2; k < inputNumbers.Count - 2; k++)
                    {
                        if (inputNumbers[i] + inputNumbers[j] + inputNumbers[k] == 2020)
                        {
                            return inputNumbers[i] * inputNumbers[j] * inputNumbers[k];
                        }
                    }
                }
            }

            return -1;
        }

    }
}
