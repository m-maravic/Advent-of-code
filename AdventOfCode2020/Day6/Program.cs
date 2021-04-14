using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        { 
            string[] inputList = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day6\input.txt");
            List<string> groups = GetGroupsFromInput(inputList);
            
            Console.WriteLine(NumberOfDistinctAnswers(groups));
            Console.WriteLine(NumberOfCommonAnswers(inputList));

            Console.ReadLine();
        }

        static int NumberOfDistinctAnswers(List<string> groups)
        {
            int result = groups.Select(group => group.Select(character => character).Distinct().Count()).Sum();

            return result;
        }

        static List<string> GetGroupsFromInput(string[] inputList)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> groups = new List<string>();

            foreach (string line in inputList)
            {
                if (string.IsNullOrEmpty(line))
                {
                    groups.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                }
                else
                {
                    stringBuilder.Append(line);
                }
            }

            return groups;
        }

        static int NumberOfDistinctAnswers(string[] inputList)
        {
            int numberOfAnswers = 0;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string line in inputList)
            {
                if (string.IsNullOrEmpty(line))
                {
                    numberOfAnswers += stringBuilder.ToString().Distinct().Count();
                    stringBuilder = new StringBuilder();
                }
                else
                {
                    stringBuilder.Append(line);
                }
            }

            return numberOfAnswers;
        }

        static int NumberOfCommonAnswers(string[] inputList)
        {
            List<string> groupAnswers = new List<string>();

            IEnumerable<string> results = inputList.Intersect(inputList, StringComparer.OrdinalIgnoreCase);
            List<string> commonAnswers = new List<string>();

            int numberOfOccurences = 0;
            int result = 0;

            foreach (string line in inputList)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (groupAnswers.Count == 1)
                    {
                        result += groupAnswers[0].Count();
                    }
                    else
                    {
                        for (int k = 0; k < groupAnswers[0].Count(); k++)
                        {
                            for (int j = 0; j < groupAnswers.Count(); j++) 
                            {
                                if (groupAnswers[j].Contains(groupAnswers[0][k]))
                                {
                                    numberOfOccurences++;
                                }
                            }

                            if (numberOfOccurences == groupAnswers.Count())
                            {
                                result += 1;
                            }

                            numberOfOccurences = 0;
                        }

                    }

                    groupAnswers = new List<string>();
                }
                else
                {
                    groupAnswers.Add(line);
                }
            }

            return result;
        }

    }
}
    
