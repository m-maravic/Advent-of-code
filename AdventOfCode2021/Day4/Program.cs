using Day4;

string input = File.ReadAllText(@"D:\Learning\Advent\Advent-of-code\AdventOfCode2021\Day4\input.txt");
string[] bingoParts = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
string[] bingoNumbers = bingoParts[0].Split(',');

List<BingoBoard> bingoBoards = new();

foreach(string bingoPart in bingoParts)
{
    bingoBoards.Add(new BingoBoard(bingoPart));
}

Console.WriteLine("Part one: {0}", GetPartOneSolution(bingoNumbers, bingoBoards));

static int GetPartOneSolution(string[] bingoNumbers, List<BingoBoard> bingoBoards)
{
    int winningNumber = 0;
    bool firstWinner = true;
    int result = 0;

    foreach(string bingoNumber in bingoNumbers)
    {
        foreach(BingoBoard bingoBoard in bingoBoards)
        {
            for (int i=0; i< bingoBoard.BoardNumbers.Count; i++) //i = red
            {
                for (int j=0; j < bingoBoard.BoardNumbers[i].Length; j++) // j = kolona
                {
                    if (bingoBoard.BoardNumbers[i][j].ToString().Equals(bingoNumber))
                    {
                        bingoBoard.NoItemsInColumnsMarked[j] += 1;
                        bingoBoard.NoItemsInRowsMarked[i] += 1;

                        if (bingoBoard.IsWinner() && firstWinner)
                        {
                            winningNumber = Int32.Parse(bingoNumber);
                            firstWinner = false;
                        }
                    }
                    else
                    {
                        bingoBoard.SumOfAllNumbers -= Int32.Parse(bingoBoard.BoardNumbers[i][j].ToString());
                    }
                }

            }

            if (!firstWinner)
            {
                result = winningNumber * bingoBoard.SumOfAllNumbers;
            }
        }
    }

    return result;
}



//bingo parts 1 - n - boards (each board, split by \n to get rows 