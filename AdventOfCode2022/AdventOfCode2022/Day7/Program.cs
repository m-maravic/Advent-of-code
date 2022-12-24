using Directory = Day7.Directory;

var directories = new List<Directory>();
var directoriesToUpdate = new List<int>();

foreach (string command in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    if (command.Contains("$ ls") || command.Contains("dir "))
    {
        continue;
    }

    if (command.Contains(".."))
    {
        directoriesToUpdate.RemoveAt(directoriesToUpdate.Count - 1);
        continue;
    }

    if (command.Contains("$ cd"))
    {
        directories.Add(new Directory(GetFileNameFromComamnd(command), 0));
        directoriesToUpdate.Add(directories.Count - 1);
        continue;
    }

    foreach (var index in directoriesToUpdate)
    {
        directories[index].AddFile(GetFileSizeFromComamnd(command));
    }

}

var partOne = directories.Where(d => d.Size <= 100000).Sum(d => d.Size);
Console.WriteLine("Part one result " + partOne);


var fileSystemSize = 70000000;
var updateSize = 30000000;
var emptySpace = fileSystemSize - directories[0].Size;

var partTwo = directories.Where(d => emptySpace + d.Size >= updateSize).Min(d => d.Size);

Console.WriteLine("Part two result " + partTwo);


int GetFileSizeFromComamnd(string command)
{
    return Int32.Parse(command.Split(' ')[0]);
}

string GetFileNameFromComamnd(string command)
{
    return command.Split(' ')[2];
}