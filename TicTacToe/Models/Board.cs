using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class Board
    {
        public List<List<Cell>> board { get; set; }

        public Board(int dimension)
        {
            board = new List<List<Cell>>();
            for(int i=0;i<dimension; i++)
            {
                var rowList = new List<Cell>();
                for(int j=0;j<dimension;j++)
                {
                    rowList.Add(new Cell(i, j));
                }
                board.Add(rowList);
            }

        }

        public void DisplayBoard()
        {
            for(int i=0;i<board.Count;i++)
            {
                for(int j=0;j<board.Count;i++)
                {
                    if (board[i][j].cellState==CellState.EMPTY)
                    {
                        Console.WriteLine("|  " + "|");
                    }
                    else
                    {
                        Console.WriteLine("| " + board[i][j].player.Symbol + "|");
                    }
                }
            }
        }
    }
}
