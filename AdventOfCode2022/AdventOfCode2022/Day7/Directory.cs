namespace Day7;

public class Directory
{
    public string Name { get; }
    public int Size { get; private set; }

    public Directory(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public void AddFile(int fileSize)
    {
        this.Size += fileSize;
    }
}

