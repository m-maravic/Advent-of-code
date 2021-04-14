using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputList = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day9\input.txt");
            List<double> inputNumbers = GetInputNumbers(inputList);

            int preambleLength = 25;

            double partOneResult = PartOne(inputNumbers, preambleLength);
            Console.WriteLine(partOneResult);

            double partTwoResult = PartTwo(inputNumbers, partOneResult);
            Console.WriteLine(partTwoResult);

            Console.ReadLine();
        }

        static double PartOne(List<double> inputNumbers, int preambleLength)
        {
            int counter = 0;
            for (int k = preambleLength; k < inputNumbers.Count(); k++)
            {
                bool foundIt = false;

                for (int i = 0 + counter; i < k; i++)
                {
                    for (int j = 1 + counter; j < k; j++)
                    {
                        if (inputNumbers[i] != inputNumbers[j] && inputNumbers[i] + inputNumbers[j] == inputNumbers[k])
                        {
                            foundIt = true;
                        }
                    }
                }

                if (!foundIt)
                {
                    return inputNumbers[k];
                }

                counter++;
            }

            return 0;
        }

        static double PartTwo(List<double> inputNumbers, double wantedSum)
        {
            double currentSum;
            for (int i = 0; i < inputNumbers.Count(); i++)
            {
                currentSum = inputNumbers[i];
                for (int j = i + 1; j <= inputNumbers.Count(); j++)
                {
                    if (currentSum == wantedSum)
                    {
                        List<double> sublist = inputNumbers.GetRange(i, j-i); 

                        return sublist.Max() + sublist.Min();
                    }

                    if (currentSum > wantedSum) 
                    {
                        break;
                    }

                    currentSum = currentSum + inputNumbers[j];
                }
            }

            return 0;
        }


        static List<double> GetInputNumbers(string[] input)
        {
            return input.Select(item => Double.Parse(item)).ToList();
        }
    }
}