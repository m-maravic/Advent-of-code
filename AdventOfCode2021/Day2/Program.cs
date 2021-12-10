
string[] inputList = File.ReadAllLines(@"D:\Learning\Advent\Advent-of-code\AdventOfCode2021\Day2\input.txt");
Console.WriteLine("Part one: {0}", GetPartOneSolution(inputList));
Console.WriteLine("Part two: {0}", GetPartTwoSolution(inputList));

static int GetPartOneSolution(string[] inputList)
{
    int horizontal = 0;
    int depth = 0;

    for(int i=0; i<inputList.Length; i++)
    {
        string[] command = inputList[i].Split(' ');
        string direction = command[0];
        int.TryParse(command[1], out int value);

        switch (direction)
        {
            case "forward":
            { 
                horizontal += value; 
                break; 
            }
            case "down":
            {
                depth += value;
                break;
            }
            case "up":
            {
                depth -= value;
                break;
            }
                
        }
    }

    return horizontal*depth;
}

static int GetPartTwoSolution(string[] inputList)
{
    int horizontal = 0;
    int depth = 0;
    int aim = 0;

    for (int i = 0; i < inputList.Length; i++)
    {
        string[] command = inputList[i].Split(' ');
        string direction = command[0];
        int.TryParse(command[1], out int value);

        switch (direction)
        {
            case "forward":
                {
                    if (aim != 0)
                    {
                        depth += value * aim;
                    }
                    horizontal += value;
                    break;
                }
            case "down":
                {
                    aim += value;
                    break;
                }
            case "up":
                {
                    aim -= value;
                    break;
                }

        }
    }

    return horizontal * depth;
}