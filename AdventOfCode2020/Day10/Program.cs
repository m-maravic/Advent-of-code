using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day10\input.txt");

            //PartOne(input);
            PartTwo(input);
            Console.ReadLine();

        }

        static void PartTwo(string[] input)
        {
            List<int> adapters = GetInputNumbers(input);
            adapters.Add(0);
            adapters.Add(adapters.Max() + 3);
            adapters.Sort();

            Dictionary<int, double> adapterNumberOfPathsDict = new Dictionary<int, double>();

            foreach (int adapter in adapters)
            {
                adapterNumberOfPathsDict.Add(adapter, 0);
            }

            int j;
            for (int i = adapterNumberOfPathsDict.Keys.Count-1; i >= 0; i--)
            {
                j = 1;
                int result = 0;
                do
                {
                    if (i + j >= adapterNumberOfPathsDict.Keys.Count())
                    {
                        break;
                    }

                    result = adapterNumberOfPathsDict.Keys.ToList()[i + j] - adapterNumberOfPathsDict.Keys.ToList()[i];

                    if (result == 1 || result == 2 || result == 3)
                    {
                        if (adapterNumberOfPathsDict[adapterNumberOfPathsDict.Keys.ToList()[i + j]] == 0)
                        {
                            adapterNumberOfPathsDict[adapterNumberOfPathsDict.Keys.ToList()[i]] += 1;
                        }
                        else
                        {
                            adapterNumberOfPathsDict[adapterNumberOfPathsDict.Keys.ToList()[i]] += adapterNumberOfPathsDict[adapterNumberOfPathsDict.Keys.ToList()[i + j]];
                        }
                    }

                    j++;
                } while (result == 1 || result == 2 || result == 3);

            }

            Console.WriteLine($"Number of possible inputs {adapterNumberOfPathsDict.First().Value}");
        }

        static void PartOne(string[] input)
        {
            List<int> adapters = GetInputNumbers(input);
            adapters.Add(0);
            adapters.Add(adapters.Max() + 3);
            adapters.Sort();

           
            int differenceOne = 0;
            int differenceTree = 0;
            int differenceTwo = 0;

            for (int i = 1; i < adapters.Count(); i++)
            {
                if (adapters[i] - adapters[i - 1] == 1)
                {
                    differenceOne++;
                }
                else if (adapters[i] - adapters[i - 1] == 3)
                {
                    differenceTree++;
                }
                else if (adapters[i] - adapters[i - 1] == 2)
                {
                    differenceTwo++;
                }
            }

            Console.WriteLine("1 jolt: " + differenceOne + "\n3 jolts: " + differenceTree + "\n2: " + differenceTwo);
            Console.WriteLine(differenceTree * differenceOne);
        }

        static List<int> GetInputNumbers(string[] input)
        {
            return input.Select(item => Int32.Parse(item)).ToList();
        }
    }
}
