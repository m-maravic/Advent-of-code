using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day5\input.txt");
            List<double> seatIDS = new List<double>();

            foreach (string binarySeat in input)
            {
                double rowNumber = FindValue(binarySeat.Substring(0, 7), 127, 0);
                double columnNumber = FindValue(binarySeat.Substring(7, 3), 7, 0);

                seatIDS.Add(rowNumber * 8 + columnNumber);
            }

            Console.WriteLine(seatIDS.Max());
            Console.WriteLine(FindMySeat(seatIDS));

            Console.ReadLine();
        }

        static double FindValue(string binaryRow, double upperValue, double lowerValue)
        {
            foreach (char character in binaryRow)
            {
                if (character.Equals('B') || character.Equals('R'))
                {
                    lowerValue = Math.Ceiling((upperValue - lowerValue) / 2 + lowerValue);
                }
                else
                {
                    upperValue = Math.Round((lowerValue + upperValue) / 2);
                }
            }

            return lowerValue;
        }

        static double FindMySeat(List<double> seatIDS)
        {
            double mySeat = 0;

            foreach (double seat in seatIDS)
            {
                if (!seatIDS.Contains(seat+1))
                {
                    mySeat = seat + 1;
                }

                if (!seatIDS.Contains(seat-1))
                {
                    mySeat = seat - 1;
                }
            }

            return mySeat;
        }
    }
}
