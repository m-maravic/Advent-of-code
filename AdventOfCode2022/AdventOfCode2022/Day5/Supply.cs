using System.Text;
using System.Text.RegularExpressions;

namespace Day5;

public class Supply
{
    private readonly Regex cratesRegex = new (@"(?:\s{4})|(?:\[\w\])");
    public Dictionary<int, Stack<string>> Crates { get; } = new Dictionary<int, Stack<string>>();

    public string GetTopItems()
    {
        StringBuilder sb = new ();
        foreach(var crate in Crates.Values)
        {
            sb.Append(crate.Peek());
        }

        return sb.ToString();
    }

    public void ReorderUsingCrateMover9000(ReorderInstruction instruction)
    {
        for(int i=0; i< instruction.NumberOfItemsToMove; i++)
        {
            var itemToMove = Crates[instruction.StartingPosition].Pop();
            Crates[instruction.FinalPosition].Push(itemToMove);
        }
    }

    public void ReorderUsingCrateMover9001(ReorderInstruction instruction)
    {
        var tempList = new List<string>();

        for (int i = 0; i < instruction.NumberOfItemsToMove; i++)
        {
            var itemToMove = Crates[instruction.StartingPosition].Pop();
            tempList.Add(itemToMove);
        }

        tempList.Reverse();

        foreach(var item in tempList)
        {
            Crates[instruction.FinalPosition].Push(item);
        }
    }

    public void AddCrateFromInput(string line)
    {
        Match m = cratesRegex.Match(line);
        int columnNumber = 1;

        while (m.Success)
        {
            for (int j = 0; j < m.Captures.Count; j++)
            {
                Capture c = m.Captures[j];

                if (string.IsNullOrWhiteSpace(c.ToString()))
                {
                    continue;
                }

                var letter = c.ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                if (!Crates.ContainsKey(columnNumber))
                {
                    var stack = new Stack<string>();
                    stack.Push(letter);
                    Crates.Add(columnNumber, stack);
                }
                else
                {
                    Crates[columnNumber].Push(letter);
                }
            }

            m = m.NextMatch();
            columnNumber++;
        }
    }
}
