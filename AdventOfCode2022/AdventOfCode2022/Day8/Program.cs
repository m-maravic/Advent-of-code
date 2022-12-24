var forestInput = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt");
var visibleTreesCount = 0;

var scores = new List<int>();

for (int x = 0; x < forestInput[0].Length; x++)
{ 
    for (int y = 0; y < forestInput.Length; y++)
    {
        var currentTreeHeight = Int32.Parse(forestInput[x][y].ToString());


        if (x == 0 || y == 0 || x == forestInput.Length - 1 || y == forestInput[0].Length - 1)
        {
            visibleTreesCount++;
            continue;
        }

        scores.Add(CalculateScenicScore(forestInput, currentTreeHeight, x, y));

        if (!SearchForHigherTrees(forestInput, "left", currentTreeHeight, x, y))
        {
            visibleTreesCount++;
            continue;
        }
        if (!SearchForHigherTrees(forestInput, "right", currentTreeHeight, x, y))
        {
            visibleTreesCount++;
            continue;
        }
        if (!SearchForHigherTrees(forestInput, "up", currentTreeHeight, x, y))
        {
            visibleTreesCount++;
            continue;
        }
        if (!SearchForHigherTrees(forestInput, "down", currentTreeHeight, x, y))
        {
            visibleTreesCount++;
            continue;
        }

    }
}

Console.WriteLine("Part one result: " + visibleTreesCount);
Console.WriteLine("Part two result: " + scores.Max());


bool SearchForHigherTrees(string[] forest, string direction, int currentTreeHeight, int x, int y)
{
    if (direction == "left")
    {
        for (int i = 0; i < x; i++)
        {
            var height = Int32.Parse(forestInput[i][y].ToString());
            if (height >= currentTreeHeight)
            {
                return true;
            }
        }
    }

    if (direction == "right")
    {
        for (int i = x + 1; i < forestInput.Length; i++)
        {
            var height = Int32.Parse(forestInput[i][y].ToString());
            if (height >= currentTreeHeight)
            {
                return true;
            }
        }
    }

    if (direction == "up")
    {
        for (int i = 0; i < y; i++)
        {
            var height = Int32.Parse(forestInput[x][i].ToString());
            if (height >= currentTreeHeight)
            {
                return true;
            }
        }
    }

    if (direction == "down")
    {
        for (int i = y + 1; i < forestInput[0].Length; i++)
        {
            var height = Int32.Parse(forestInput[x][i].ToString());
            if (height >= currentTreeHeight)
            {
                return true;
            }
        }
    }

    return false;
}


int CalculateScenicScore(string[] forest, int currentTreeHeight, int x, int y)
{
    var scores = new List<int>();
    var treeCounter = 0;

    //up
    for(int i=y-1; i>=0; i--)
    {
        treeCounter++;
        var height = Int32.Parse(forestInput[x][i].ToString());
        if (height >= currentTreeHeight)
        {
            break;
        }
    }
    scores.Add(treeCounter);

    //down
    treeCounter = 0;
    for (int i = y + 1; i < forest.Length; i++)
    {
        treeCounter++;
        var height = Int32.Parse(forestInput[x][i].ToString());
        if (height >= currentTreeHeight)
        {
            break;
        }
    }
    scores.Add(treeCounter);

    //left
    treeCounter = 0;
    for (int i = x -1; i >= 0; i--)
    {
        treeCounter++;
        var height = Int32.Parse(forestInput[i][y].ToString());
        if (height >= currentTreeHeight)
        {
            break;
        }
    }
    scores.Add(treeCounter);

    // right
    treeCounter = 0;
    for (int i = x + 1; i < forestInput[0].Length; i++)
    {
        treeCounter++;
        var height = Int32.Parse(forestInput[i][y].ToString());
        if (height >= currentTreeHeight)
        {
            break;
        }
    }
    scores.Add(treeCounter);

    return scores.Count > 0 ? scores.Aggregate((a, x) => a * x) : 0;
}