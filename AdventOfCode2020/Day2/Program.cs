using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Input> inputList = GetInput(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day2\input.txt");

            int task1 = GetNumberOfValidPasswordsTask1(inputList);
            Console.WriteLine($"Task1: {task1}");

            int task2 = GetNumberOfValidPasswordsTask2(inputList);
            Console.WriteLine($"Task2: {task2}");

            Console.ReadLine();
        }

        public static List<Input> GetInput(string filePath)
        {
            List<Input> inputList = new List<Input>();
            string line;

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    Input input = new Input();
                    string[] temp = line.Split('-');
                    string[] temp2 = temp[1].Split(' ');
                    string[] temp3 = temp2[1].Split(':');

                    input.DownValue = Int32.Parse(temp[0]);
                    input.UpValue = Int32.Parse(temp2[0]);
                    input.Password = temp2[2];
                    input.Letter = temp3[0];

                    inputList.Add(input);
                }

                file.Close();
            }

            return inputList;
        }

        public static int GetNumberOfValidPasswordsTask1(List<Input> inputList)
        {
            int counter = 0;

            foreach (Input input in inputList)
            {
                int occurenceCount = Regex.Matches(input.Password, input.Letter).Count;

                if (occurenceCount >= input.DownValue && occurenceCount <= input.UpValue)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int GetNumberOfValidPasswordsTask2(List<Input> inputList)
        {
            int counter = 0;

            foreach (Input input in inputList)
            {
                if ((input.Password[input.DownValue - 1].ToString() == input.Letter) != ((input.Password[input.UpValue - 1].ToString() == input.Letter)))
                {
                    counter++;
                }
            }

            return counter;
        }

        public void ParseWithRegex(List<Input> inputList)
        {
            Regex regex = new Regex(@"(?<down>([0-9]))-(?<up>([0-9])) (?<letter>([a-z])): (?<password>([a-z]*))", RegexOptions.Compiled);
            MatchCollection matches = Regex.Matches(inputList.ToString(), regex.ToString());

            Console.WriteLine("Start: {0}", matches[0].Groups["date"].Value);

            foreach (Match match in matches)
            {
                Int32.TryParse(match.Groups["down"].Value, out int downValue);
                Int32.TryParse(match.Groups["up"].Value, out int upperValue);
                string letter = match.Groups["letter"].Value;
                string password = match.Groups["password"].Value;
            }
        }

    }
}
