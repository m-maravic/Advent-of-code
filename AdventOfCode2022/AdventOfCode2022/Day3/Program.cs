var backpacks = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt").ToList();

int sumOfPriorities = 0;
int lowerCaseCharDifference = 38;
int upperCaseCharDifference = 96;

foreach (string backpack in backpacks)
{
    int departmentSize = (int)Math.Round((decimal)backpack.Length / 2);
    var departmentOneAsciiCodes = backpack.Substring(0, departmentSize).Select(c => (int)c);
    var departmentTwoAsciiCodes = backpack.Substring(departmentSize, departmentSize).Select(c => (int)c);

    var duplicate = departmentOneAsciiCodes.First(c => departmentTwoAsciiCodes.Contains(c));

    sumOfPriorities += getPriority(duplicate);
}

bool isUpperCase(int charcterAscii)
{
    return charcterAscii > 90;
}

int getPriority(int characterAscii)
{
    return isUpperCase(characterAscii) ?
        characterAscii - upperCaseCharDifference :
        characterAscii - lowerCaseCharDifference;
}

Console.WriteLine($"Part one result {sumOfPriorities}");

int sumOfBadgesPriorities = 0;
for(int i = 0; i < backpacks.Count; i+=3)
{
    var elfOneBackpack = backpacks[i].Select(l => (int)l);
    var elfTwoBackpack = backpacks[i+1].Select(l => (int)l);
    var elfThreeBackpack = backpacks[i+2].Select(l => (int)l);

    foreach(int item in elfOneBackpack)
    {
        if (elfTwoBackpack.Contains(item) && elfThreeBackpack.Contains(item))
        {
            sumOfBadgesPriorities += getPriority(item);
            break;
        }
    }
}

Console.WriteLine($"Part two result {sumOfBadgesPriorities}");
