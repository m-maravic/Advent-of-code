var points = 0;
var pointsPerLetter = new Dictionary<string, int>
{
    { "X", 1 },
    { "Y", 2 },
    { "Z", 3 }
};

var winningCombo = new Dictionary<string, string>
{
    {"A", "Y"},
    {"B", "Z"},
    {"C", "X" }
};

var legend = new Dictionary<string, string>
{
    {"A", "X"},
    {"B", "Y"},
    {"C", "Z" }
};

foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    var match = line.Split(' ');

    points += winningCombo[match[0]] == match[1] ? 
        pointsPerLetter[match[1]] + 6 : legend[match[0]] == match[1] ?  //won
        pointsPerLetter[match[1]] + 3 :                                 //draw
        pointsPerLetter[match[1]];                                      //lost
}

Console.WriteLine($"Part one result {points}");


points = 0;
var played = "";
var instructions = new Dictionary<string, int>
{
    { "X", 0 }, 
    { "Y", 1 },
    { "Z", 2 } 
};


foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    var match = line.Split(' ');

    switch (instructions[match[1]])
    {
        case 2: // need to win
            played = winningCombo[match[0]];
            points += pointsPerLetter[played] + 6;
            break;
        case 1:  // draw
            played = legend[match[0]];
            points += pointsPerLetter[played] + 3;
            break;
        default: //loose
            played = legend.Values.First(value => winningCombo[match[0]] != value && legend[match[0]] != value);
            points += pointsPerLetter[played];
            break;
    }
}

Console.WriteLine($"Part two result {points}");
