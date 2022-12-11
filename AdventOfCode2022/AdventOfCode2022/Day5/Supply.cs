using System.Text;
using System.Text.RegularExpressions;

namespace Day5;

public class Supply
{
    private Regex cratesRegex = new Regex(@"(?:\s{4})|(?:\[\w\])");
    public Dictionary<int, Stack<string>> Crates { get; } = new Dictionary<int, Stack<string>>();

    public string GetTopItems()
    {
        StringBuilder sb = new StringBuilder();
        foreach(var crate in Crates.Values)
        {
            sb.Append(crate.Pop());
        }

        return sb.ToString();
    }

    public void Reorder(ReorderInstruction instruction)
    {
        for(int i=0; i< instruction.NumberOfItemsToMove; i++)
        {
            var itemToMove = Crates[instruction.StartingPosition].Pop();
            Crates[instruction.FinalPosition].Push(itemToMove);
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
