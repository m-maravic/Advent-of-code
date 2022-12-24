using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class BingoBoard
    {
        public int[] NoItemsInRowsMarked { get; set; }
        public int[] NoItemsInColumnsMarked { get; set; }
        public List<string> BoardNumbers { get; set; }
        public int SumOfAllNumbers { get; set; }
        public BingoBoard(string board)
        {
            BoardNumbers = board.Split('\n').ToList();
            NoItemsInRowsMarked = new int[BoardNumbers.Count];
            NoItemsInColumnsMarked = new int[BoardNumbers[0].Length];
            SumOfAllNumbers = 0;
      
            foreach(var boardRow in BoardNumbers)
            {
                for(int i=0; i<boardRow.Length; i++)
                {
                    SumOfAllNumbers += Int32.Parse(boardRow[i].ToString());
                }
            }
        }

        public bool IsWinner()
        {
            foreach (int rowMarked in NoItemsInRowsMarked)
            {
                if (rowMarked == NoItemsInRowsMarked.Length)
                {
                    return true;
                }
            }

            foreach (int columnMarked in NoItemsInColumnsMarked)
            {
                if (columnMarked == NoItemsInColumnsMarked.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
