using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
			string[] inputList = File.ReadAllLines(@"D:\Learning\Advent\Advent-of-code\AdventOfCode2021\Day1\input.txt");

			int partOneResult = GetPartOneResult(inputList);
			int partTwoResult = GetPartTwoResult(inputList);

			Console.WriteLine("Part one: {0} ", partOneResult);
			Console.WriteLine("Part two: {0} ", partTwoResult);
			Console.ReadLine();
		}

		public static int GetPartTwoResult(string[] inputList)
        {
			int counter = 0;

			for (int i = 0; i < inputList.Length; i++)
			{
				if (i+1 >= inputList.Length || i+2 >= inputList.Length || i+3 >= inputList.Length) { break; }

				int.TryParse(inputList[i], out int A1);
				int.TryParse(inputList[i + 1], out int A2);
				int.TryParse(inputList[i + 2], out int A3);

				int.TryParse(inputList[i + 1], out int B1);
				int.TryParse(inputList[i + 2], out int B2);
				int.TryParse(inputList[i + 3], out int B3);

				if (B1+B2+B3 > A1+A2+A3)
				{
					counter++;
				}
			}

			return counter;
		}

		public static int GetPartOneResult(string[] inputList)
        {
            int counter = 0;

            for (int i = 0; i < inputList.Length; i++)
			{
				if (i == 0) { continue; }

				int.TryParse(inputList[i - 1], out int previousValue);
                int.TryParse(inputList[i], out int currentValue);

				if (currentValue > previousValue)
				{
					counter++;
				}
			}

			return counter;
		}
    }
}
