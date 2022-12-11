var datastream = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt");

var startOfPacketMarker = FindMessageMarker(datastream.First(), 4);
var startOfMessageMarker = FindMessageMarker(datastream.First(), 14);

Console.WriteLine("Part one result: " + startOfPacketMarker);
Console.WriteLine("Part two result: " + startOfMessageMarker);

int FindMessageMarker(string message, int markerLength)
{
    int numberOfCharacters = 0;
    for (int i = 0; i < message.Length; i++)
    {
        if (message.Substring(i, markerLength).Distinct().Count() == markerLength)
        {
            numberOfCharacters = i + markerLength;
            break;
        }
    }

    return numberOfCharacters;
}
