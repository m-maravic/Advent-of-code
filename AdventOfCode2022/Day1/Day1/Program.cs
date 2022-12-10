var currentSum = 0;
var maxSum = 0;

foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    var isNumber = int.TryParse(line, out var currentNumber);
    
    if (isNumber)
    {
        currentSum += currentNumber;
        if (currentSum > maxSum)
        {
            maxSum = currentSum;
        }
    }
    else
    {
        currentSum = 0;
    }
}

Console.WriteLine($"First part result: {maxSum}");


var caloriesPerElf = new List<int>();
currentSum = 0;

foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    var isNumber = int.TryParse(line, out var currentNumber);

    if (isNumber)
    {
        currentSum += currentNumber;
    }
    else
    {
        caloriesPerElf.Add(currentSum);
        currentSum = 0;
    }
}

caloriesPerElf.Sort();
Console.WriteLine($"Part two result:{caloriesPerElf[^1] + caloriesPerElf[^2] + caloriesPerElf[^3]}");