// See https://aka.ms/new-console-template for more information
string[] inputList = File.ReadAllLines(@"D:\Learning\Advent\Advent-of-code\AdventOfCode2021\Day3\input.txt");
Console.WriteLine("Part one: {0}", GetPartOneSolution(inputList));
Console.WriteLine("Part two: {0}", GetPartTwoSolution(inputList.ToList()));



static int GetPartOneSolution(string[] inputArray)
{
    int size = inputArray[0].Length;
    int numberOfElements = inputArray.Length;

    char[] gammaRate = new char[size];
    char[] epsilonRate = new char[size];
    int[] numberOfOnes = new int[size];

    foreach (string input in inputArray)
    {
        for (int i=0; i<input.Length; i++)
        {
            if (input[i] == '1')
            {
                numberOfOnes[i] = numberOfOnes[i] + 1;
            }
        }
    }

    for(int i=0; i < size; i++)
    {
        gammaRate[i] = numberOfOnes[i] > numberOfElements - numberOfOnes[i] ? '1' : '0';
        epsilonRate[i] = numberOfOnes[i] > numberOfElements - numberOfOnes[i] ? '0' : '1';
    }

    return Convert.ToInt32(new String(gammaRate), 2)* Convert.ToInt32(new String(epsilonRate), 2);
}


static int GetPartTwoSolution(List<string> inputList)
{
    string oxygenRatingBinary = GetRating(inputList, 0, '1', '0').First();
    string c02RatingBinary = GetRating(inputList, 0, '0', '1').First();

    return Convert.ToInt32(oxygenRatingBinary, 2) * Convert.ToInt32(c02RatingBinary, 2);

}

static List<string> GetRating(List<string> inputList, int bitToConsider, char firstValue, char secondValue)
{
    int size = inputList.First().Length;
    int numberOfElements = inputList.Count;
    int numberOfOnes = 0;

    if (inputList.Count == 1)
    {
        return inputList;
    }

    foreach (string input in inputList)
    {
        if (input[bitToConsider] == '1')
        {
            numberOfOnes += 1;
        }
    }

    char keeperValue = numberOfOnes >= numberOfElements - numberOfOnes ? firstValue : secondValue;
    return GetRating(inputList.Where(listItem => listItem[bitToConsider].Equals(keeperValue)).ToList(), ++bitToConsider, firstValue, secondValue);
   
}