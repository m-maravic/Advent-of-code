using System.Text.RegularExpressions;

namespace Day5;
public class ReorderInstruction
{
    public int NumberOfItemsToMove { get; }
    public int StartingPosition { get; }
    public int FinalPosition { get; }

    public ReorderInstruction(int numberOfItemsToMove, int startingPosition, int finalPosition)
    {
        NumberOfItemsToMove = numberOfItemsToMove;
        StartingPosition = startingPosition;
        FinalPosition = finalPosition;
    }

   public static ReorderInstruction Create(string line)
   {
        var tempList = new List<int>();
        var rearrangementRegex = new Regex(@"(?:\d*)");
        Match m1 = rearrangementRegex.Match(line);
        while (m1.Success)
        {
            for (int j = 0; j < m1.Captures.Count; j++)
            {
                Capture c = m1.Captures[j];

                if (string.IsNullOrWhiteSpace(c.ToString()))
                {
                    continue;
                }

                if (tempList.Count < 3)
                {
                    tempList.Add(Int32.Parse(c.ToString()));
                    continue;
                }
            }

            m1 = m1.NextMatch();
        }

        return new ReorderInstruction(tempList[0], tempList[1], tempList[2]);
    }
}

