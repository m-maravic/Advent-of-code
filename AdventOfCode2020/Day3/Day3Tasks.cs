using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Day3Tasks
    {
        List<List<char>> inputGrid; 

        public Day3Tasks()
        {
            inputGrid = new List<List<char>>();
            GetInput(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day3\input.txt");
        }

        public long Task2()
        {
            return (long)FindTrees(1, 1)* FindTrees(1, 3) * FindTrees(1, 5) * FindTrees(1, 7) * FindTrees(2, 1);
        }

        public int FindTrees(int gridStep, int rowStep)
        {
            int numberOfTrees = 0;
            int index = 0;

            for(int i= 0; i < inputGrid.Count; i = i + gridStep)
            {
                if (inputGrid[i][index] == '#')
                {
                    numberOfTrees++;
                }

                index = index + rowStep;
            }

            return numberOfTrees;
        }

        public void GetInput(string filePath)
        {
            string line;
            int lineNumber = 0;

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    List<char> oneRow = new List<char>();
                    lineNumber = lineNumber + 8;

                    while (oneRow.Count < lineNumber)
                    {
                        foreach (char c in line)
                        {  
                            oneRow.Add(c);
                        }
                    }
                    inputGrid.Add(oneRow);
                }

                file.Close();
            }
        }

    }
}
