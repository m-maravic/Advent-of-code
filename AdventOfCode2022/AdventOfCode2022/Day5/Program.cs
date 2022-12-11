using Day5;
using System.Text.RegularExpressions;

var input = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt").ToList();

Supply supply = new();
Stack<ReorderInstruction> procedures = new();

for(int k=input.Count-1; k>=0; k--)
{
    if (input[k].Contains("move")){
        procedures.Push(ReorderInstruction.Create(input[k]));
        continue;
    }

    supply.AddCrateFromInput(input[k]);
}

while (procedures.Count > 0)
{
    supply.Reorder(procedures.Pop());
}

Console.WriteLine($"Part one result: {0}", supply.GetTopItems());