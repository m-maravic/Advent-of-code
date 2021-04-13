using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    class PasswordValidator
    {

        List<string> inputLines;

        public PasswordValidator()
        {
            inputLines = GetInput(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day2\input.txt");
        }

        public void ParseWithRegex()
        {
            Regex regex = new Regex(@"(?<down>([0-9]))-(?<up>([0-9])) (?<letter>([a-z])): (?<password>([a-z]*))", RegexOptions.Compiled);
            MatchCollection matches = Regex.Matches(inputLines.ToString(), regex.ToString());

            Console.WriteLine("Start: {0}", matches[0].Groups["date"].Value);

            foreach (Match match in matches)
            {
                Int32.TryParse(match.Groups["down"].Value, out int downValue);
                Int32.TryParse(match.Groups["up"].Value, out int upperValue);
                string letter = match.Groups["letter"].Value;
                string password = match.Groups["password"].Value;

            }
        }

        public int GetNumberOfValidPasswords()
        {
            int counter = 0;

            foreach(string inputLine in inputLines)
            {
                string[] temp = inputLine.Split('-'); 
                string[] temp2 = temp[1].Split(' '); 
                string[] temp3 = temp2[1].Split(':'); 

                int downValue = Int32.Parse(temp[0]);
                int upperValue = Int32.Parse(temp2[0]);
                string password = temp2[2];
                string letter = temp3[0];

                int occurenceCount = Regex.Matches(password, letter).Count;

                if (occurenceCount >= downValue && occurenceCount <= upperValue)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int GetNumberOfValidPasswords2()
        {
            int counter = 0;

            foreach (string inputLine in inputLines)
            {
                string[] temp = inputLine.Split('-');
                string[] temp2 = temp[1].Split(' ');
                string[] temp3 = temp2[1].Split(':');

                int downValue = Int32.Parse(temp[0]);
                int upperValue = Int32.Parse(temp2[0]);
                string password = temp2[2];
                string letter = temp3[0];


                //if (password[downValue - 1].ToString() == letter && password[upperValue - 1].ToString() != letter)
                //{
                //    counter++;
                //}
                //if (password[downValue - 1].ToString() != letter && password[upperValue - 1].ToString() == letter)
                //{
                //    counter++;
                //}

                if ((password[downValue - 1].ToString() == letter) != ((password[upperValue - 1].ToString() == letter)))
                {
                    counter++;
                }

            }

            return counter;
        }

        public List<string> GetInput(string filePath)
        {
            List<string> input = new List<string>();
            string line;

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    input.Add(line);
                }
                file.Close();
            }

            return input;
        }
    }
}
