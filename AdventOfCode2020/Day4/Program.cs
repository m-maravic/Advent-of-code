using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day4\input.txt");

            Console.WriteLine(PassportsWithAllFields(input));

            List<Passport> passports = GetPassports(input);
            Console.WriteLine("Task 2: " + CountValidPassports(passports));

            Console.ReadLine();
        }

        public static int CountValidPassports(List<Passport> passports)
        {
            int numberOfValidPassports = 0;

            foreach(Passport passport in passports)
            {
                if (passport.IsValid())
                {
                    numberOfValidPassports++;
                }
            }

            return numberOfValidPassports;
        }

        public static int PassportsWithAllFields(string[] input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int validNumber = 0;

            foreach(string line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    string passport = stringBuilder.ToString();
                    if (passport.Contains("ecl") && passport.Contains("pid") && passport.Contains("eyr")
                        && passport.Contains("hcl") && passport.Contains("byr") && passport.Contains("iyr") && passport.Contains("hgt"))
                    {
                        validNumber++;
                    }

                    stringBuilder = new StringBuilder();
                }
                else
                {
                    stringBuilder.Append(line);
                }
            }

            return validNumber;
        }

        public static List<Passport> GetPassports(string[] input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<Passport> passports = new List<Passport>();

            Regex reg = new Regex(@"^(?=.*byr:((19[2-9]\d)|200[0-2])\s)(?=.*iyr:((201[0-9])|2020)\s)(?=.*eyr:((202[0-9])|2030)\s)(?=.*hgt:(((59|6[0-9]|7[0-6])in)|((1[5-8][0-9]|19[0-3])cm))\s)(?=.*hcl:#[0-9a-f]{6}\s)(?=.*ecl:(amb|blu|brn|gry|grn|hzl|oth)\s)(?=.*pid:\d{9}\s)", RegexOptions.Compiled);
            MatchCollection match = Regex.Matches(input[4], reg.ToString());

            foreach (string line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    passports.Add(GetPassportFromString(stringBuilder.ToString()));
                    stringBuilder = new StringBuilder();
                }
                else
                {
                    stringBuilder.Append(line);
                }
            }

            return passports;
        }

        public static Passport GetPassportFromString(string passportString)
        {
            MatchCollection matches;

            Passport passport = new Passport();

            Regex byrPattern = new Regex(@"(byr:)(?<byr>([0-9]{4}))", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, byrPattern.ToString());
            if (matches.Count > 0)
            {
                passport.byr = Int32.Parse(matches[0].Groups["byr"].Value);
            }

            Regex hclPattern = new Regex(@"(?<name>(hcl:#))(?<hcl>([a-fA-F0-9]{6}))", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, hclPattern.ToString());
            if (matches.Count > 0)
            {
                passport.hcl = matches[0].Groups["hcl"].Value;
            }

            Regex iyrPattern = new Regex(@"(iyr:)(?<iyr>([0-9]{4}))", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, iyrPattern.ToString());
            if (matches.Count > 0)
            {
                passport.iyr = Int32.Parse(matches[0].Groups["iyr"].Value);
            }

            Regex eyrPattern = new Regex(@"(eyr:)(?<eyr>([0-9]{4}))", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, eyrPattern.ToString());
            if (matches.Count > 0)
            {
                passport.eyr = Int32.Parse(matches[0].Groups["eyr"].Value);
            }

            Regex hgtcmPattern = new Regex(@"(hgt:)(?<hgtcm>([0-9]{3}))(cm)", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, hgtcmPattern.ToString());
            if (matches.Count > 0)
            {
                passport.hgtcm = Int32.Parse(matches[0].Groups["hgtcm"].Value);
            }

            Regex hgtinchPattern = new Regex(@"(hgt:)(?<hgtin>([0-9]{2}))(in)", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, hgtinchPattern.ToString());
            if (matches.Count > 0)
            {
                passport.hgtin = Int32.Parse(matches[0].Groups["hgtin"].Value);
            }

            Regex eclPattern = new Regex(@"(ecl:)(?<ecl>([a-z]{3}))", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, eclPattern.ToString());
            if (matches.Count > 0)
            {
                passport.ecl = matches[0].Groups["ecl"].Value;
            }

            Regex pidPattern = new Regex(@"(pid:)(?<pid>([0-9]*))", RegexOptions.Compiled);
            matches = Regex.Matches(passportString, pidPattern.ToString());
            if (matches.Count > 0)
            {
                passport.pid = matches[0].Groups["pid"].Value;
            }

            return passport;

        }
    }
}
