using System;
using System.Collections.Generic;
using System.IO;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"D:\Learning\Advent\Advent-of-code\AdventOfCode2020\Day11\input.txt");
            List<char[]> seats = new();
            for (int i = 0; i < input.Length; i++)
            {
                seats.Add(input[i].ToCharArray());
            }

            //int partOneResult = SolvePartOne(seats);
            //Console.WriteLine("Part one: {0}", partOneResult);

            int partTwoResult = SolvePartTwo(seats);
            Console.WriteLine("Part two: {0}", partTwoResult);

            Console.ReadLine();
        }

        private static int SolvePartTwo(List<char[]> seats)
        {
            List<Tuple<int, int>> seatsToChange;

            do
            {
                seatsToChange = new List<Tuple<int, int>>();

                for (int i = 0; i < seats.Count; i++)
                {
                    for (int j = 0; j < seats[0].Length; j++)
                    {
                        if (seats[i][j].Equals('.')) continue;

                        if (seats[i][j].Equals('L') && numberOfVisibleOccupied(seats, i, j) == 0)
                        {
                            seatsToChange.Add(new Tuple<int, int>(i, j));
                        }
                        else if (seats[i][j].Equals('#') && numberOfVisibleOccupied(seats, i, j) >= 5)
                        {
                            seatsToChange.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }

                foreach (var seatToChange in seatsToChange)
                {
                    seats[seatToChange.Item1][seatToChange.Item2] = seats[seatToChange.Item1][seatToChange.Item2] == 'L' ? '#' : 'L';
                }

                //foreach(var seatsRow in seats)
                //{
                //    foreach(var seat in seatsRow) 
                //    {
                //        Console.Write(seat);
                //    }
                //    Console.Write('\n');
                //}
                //Console.Write("--------------------\n");

            } while (seatsToChange.Count > 0);

            int counter = 0;
            foreach (var seatArray in seats)
            {
                foreach (var seat in seatArray)
                {
                    if (seat.Equals('#'))
                    {
                        counter++;
                    }
                }
            }

            return counter;

        }

        private static int numberOfVisibleOccupied(List<char[]> seats, int i, int j)
        {
            int maxI = i + 1;
            int maxJ = j + 1;

            int minI = i - 1;
            int minJ = j - 1;

            int numberOfOccupied = 0;

            do
            {
                if (seatExists(seats, minI, minJ) && seats[minI][minJ].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, minI, minJ) && seats[minI][minJ].Equals('L'))
                {
                    break;
                }

                    minI--;
                minJ--;

            } while (seatExists(seats, minI, minJ));

            maxI = i + 1;
            maxJ = j + 1;

            minI = i - 1;
            minJ = j - 1;

            do
            {
              
                if (seatExists(seats, minI, j) && seats[minI][j].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, minI, j) && seats[minI][j].Equals('L'))
                {
                    break;
                }

                minI--;

            } while (seatExists(seats, minI, j));

            maxI = i + 1;
            maxJ = j + 1;

            minI = i - 1;
            minJ = j - 1;

            do
            {
                if (seatExists(seats, minI, maxJ) && seats[minI][maxJ].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, minI, maxJ) && seats[minI][maxJ].Equals('L'))
                {
                    break;
                }

                minI--;
                maxJ++;

            } while (seatExists(seats, minI, maxJ));

            maxI = i + 1;
            maxJ = j + 1;

            minI = i - 1;
            minJ = j - 1;

            do
            {
                if (seatExists(seats, i, minJ) && seats[i][minJ].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, i, minJ) && seats[i][minJ].Equals('L'))
                {
                    break;
                }

                minJ--;

            } while (seatExists(seats, i, minJ));

            maxI = i + 1;
            maxJ = j + 1;

            minI = i - 1;
            minJ = j - 1;

            do
            {
                if (seatExists(seats, i, maxJ) && seats[i][maxJ].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, i, maxJ) && seats[i][maxJ].Equals('L'))
                {
                    break;
                }

                maxJ++;

            } while (seatExists(seats, i, maxJ));

            maxI = i + 1;
            maxJ = j + 1;

            minI = i - 1;
            minJ = j - 1;

            do
            {
                if (seatExists(seats, maxI, minJ) && seats[maxI][minJ].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, maxI, minJ) && seats[maxI][minJ].Equals('L'))
                {
                    break;
                }

                maxI++;
                minJ--;

            } while (seatExists(seats, maxI, minJ));

            maxI = i + 1;
            maxJ = j + 1;

            minI = i - 1;
            minJ = j - 1;

            do
            {
                if (seatExists(seats, maxI, j) && seats[maxI][j].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, maxI, j) && seats[maxI][j].Equals('L'))
                {
                    break;
                }

                maxI++;

            } while (seatExists(seats, maxI, j));

            maxI = i + 1;
            maxJ = j + 1;

            minI = i - 1;
            minJ = j - 1;

            do
            {
                if (seatExists(seats, maxI, maxJ) && seats[maxI][maxJ].Equals('#'))
                {
                    numberOfOccupied++;
                    break;
                }

                if (seatExists(seats, maxI, maxJ) && seats[maxI][maxJ].Equals('L'))
                {
                    break;
                }

                maxI++;
                maxJ++;

            } while (seatExists(seats, maxI, maxJ));

            return numberOfOccupied;
        }

        private static int SolvePartOne(List<char[]> seats)
        {
            List<Tuple<int, int>> seatsToChange;

            do
            {
                seatsToChange = new List<Tuple<int, int>>();

                for (int i = 0; i < seats.Count; i++)
                {
                    for (int j = 0; j < seats[0].Length; j++)
                    {
                        if (seats[i][j].Equals('.')) continue;

                        if (seats[i][j].Equals('L') && numberOfAdjasentOccupied(seats, i, j) == 0)
                        {
                            seatsToChange.Add(new Tuple<int, int>(i, j));
                        }
                        else if (seats[i][j].Equals('#') && numberOfAdjasentOccupied(seats, i, j) >= 4)
                        {
                            seatsToChange.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }

                foreach (var seatToChange in seatsToChange)
                {
                    seats[seatToChange.Item1][seatToChange.Item2] = seats[seatToChange.Item1][seatToChange.Item2] == 'L' ? '#' : 'L';
                }

            } while (seatsToChange.Count > 0);

            int counter = 0;
            foreach (var seatArray in seats)
            {
                foreach (var seat in seatArray)
                {
                    if (seat.Equals('#'))
                    {
                        counter++;
                    }
                }
            }

            return counter;

        }

        private static int numberOfAdjasentOccupied(List<char[]> seats, int i, int j)
        {
            int maxI = i + 1;
            int maxJ = j + 1;

            int minI = i - 1;
            int minJ = j - 1;

            int numberOfOccupied = 0;

            if (seatExists(seats, minI, minJ) && seats[minI][minJ].Equals('#'))
                numberOfOccupied++;
            if (seatExists(seats, minI, j) && seats[minI][j].Equals('#'))
                numberOfOccupied++;
            if (seatExists(seats, minI, maxJ) && seats[minI][maxJ].Equals('#'))
                numberOfOccupied++;
            if (seatExists(seats, i, minJ) && seats[i][minJ].Equals('#'))
                numberOfOccupied++;
            if (seatExists(seats, i, maxJ) && seats[i][maxJ].Equals('#'))
                numberOfOccupied++;
            if (seatExists(seats, maxI, minJ) && seats[maxI][minJ].Equals('#'))
                numberOfOccupied++;
            if (seatExists(seats, maxI, j) && seats[maxI][j].Equals('#'))
                numberOfOccupied++;
            if (seatExists(seats, maxI, maxJ) && seats[maxI][maxJ].Equals('#'))
                numberOfOccupied++;

            return numberOfOccupied;
        }

        private static bool seatExists(List<char[]> seats, int i, int j)
        {
            if (i >= seats.Count || j >= seats[0].Length || i < 0 || j < 0)
            {
                return false;
            }

            return true;
        }
      
    }
}
