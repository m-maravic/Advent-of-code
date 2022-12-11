int counter = 0;

foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    var ranges = line.Split(",");
    var rangeOne = ranges[0].Split("-").Select(c => Int32.Parse(c)).ToList();
    var rangeTwo = ranges[1].Split("-").Select(c => Int32.Parse(c)).ToList();

    if (rangeOne[0] <= rangeTwo[0] && rangeOne[1] >= rangeTwo[1] ||
        rangeTwo[0] <= rangeOne[0] && rangeTwo[1] >= rangeOne[1])
    {
        counter++;
    }
}
Console.WriteLine($"Part one result: {counter}");

counter = 0;

foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    var ranges = line.Split(",");
    var rangeOne = ranges[0].Split("-").Select(c => Int32.Parse(c)).ToList();
    var rangeTwo = ranges[1].Split("-").Select(c => Int32.Parse(c)).ToList();
    

    if (rangeOne[0] <= rangeTwo[0] && !(rangeOne[1] < rangeTwo[0]) ||
        rangeTwo[0] <= rangeOne[0] && !(rangeTwo[1] < rangeOne[0]))
    {
        counter++;
    }
}

Console.WriteLine($"Part two result: {counter}");