using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        static List<Bag> allBags;

        static void Main(string[] args)
        {
            string[] inputList = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day7\input.txt");
            allBags = GetBagsFromInput(inputList);

            int partOneResult = 0;
            allBags.ForEach(bag =>
            {
                if (GoldBagsInside(bag.Color) > 0)
                    partOneResult++;
            });

            Console.WriteLine(partOneResult);
            Console.WriteLine(GetNumberOfBags(("shiny gold").Trim()) - 1);

            Console.ReadLine();
        }

        static int GoldBagsInside(string bagColor)
        {
            int result = 0;
            Bag bagWithInner = allBags.Where(b => b.Color.Contains(bagColor.Trim())).FirstOrDefault();

            foreach (Bag bag in bagWithInner.Bags.Select(b => b.Item2))
            {
                if (bag.Color.Equals("shiny gold"))
                {
                    result++;
                }

                result += GoldBagsInside(bag.Color);
            }

            return result;
        }

        static int GetNumberOfBags(string bagColor)
        {
            int result = 1;

            Bag currentBag = allBags.Where(b => b.Color.Contains(bagColor)).FirstOrDefault();

            foreach (Tuple<int, Bag> bagTouple in currentBag.Bags)
            {
                result = result + bagTouple.Item1 * GetNumberOfBags(bagTouple.Item2.Color.Trim());
            }

            return result;
        }

        static List<Bag> GetBagsFromInput(string[] inputList)
        {
            List<Bag> allBags = new List<Bag>();
            Regex regex = new Regex(@"(?<number>([0-9]))?(?<color>([a-z ]*)) bag", RegexOptions.Compiled);

            foreach (string input in inputList)
            {
                MatchCollection matches = Regex.Matches(input, regex.ToString());

                if (matches.Count > 0)
                {
                    Bag bag = new Bag();
                    bag.Color = matches[0].Groups["color"].Value.Trim();

                    if (!input.Contains("no other"))
                    {
                        for (int i = 1; i < matches.Count; i++)
                        {
                            bag.Bags.Add(new Tuple<int, Bag>(Int32.Parse(matches[i].Groups["number"].Value), new Bag() { Color = matches[i].Groups["color"].Value.Trim() }));
                        }
                    }

                    allBags.Add(bag);
                }

            }

            return allBags;

        }

        public static int PartOne()
        {
            Dictionary<string, List<Bag>> flatBags = new Dictionary<string, List<Bag>>();

            foreach (Bag bag in allBags)
            {
                flatBags.Add(bag.Color, GetAllNestedBags(bag.Color));
            }

            int numberOfBags = 0;

            foreach (List<Bag> listBag in flatBags.Values)
            {
                if (listBag.Where(b => b.Color.Equals(("shiny gold").Trim())).FirstOrDefault() != null)
                {
                    numberOfBags++;
                }
            }

            return numberOfBags;
        }

      
        private static List<Bag> GetAllNestedBags(string bagColor)
        {
            List<Bag> nestedBags = new List<Bag>();
            Bag bagWithInner = allBags.Where(b => b.Color == bagColor).FirstOrDefault();

            if (bagWithInner != null)
            {
                nestedBags.AddRange(bagWithInner.Bags.Select(b => b.Item2));

                foreach (Bag innerBag in bagWithInner.Bags.Select(b => b.Item2))
                {
                    nestedBags.AddRange(GetAllNestedBags(innerBag.Color));
                }
            }

            return nestedBags;
        }

      
    }
}
