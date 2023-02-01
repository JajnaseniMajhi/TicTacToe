using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PlayerType PlayerType { get; set; }
        public string Symbol { get; set; }

        public int[] rowCount { get; set; }
        public int[] colCount { get; set; }
        public int leftDiag { get; set; }
        public int rightDiag { get; set; }

        private int inValidCount { get; set; }

        public Player(int id, string name, PlayerType playerType, string symbol, int dimension)
        {
            Id = id;
            Name = name;
            PlayerType = playerType;
            Symbol = symbol;
            //leftDiag = new int[dimension];
            //rightDiag = new int[];
            rowCount = new int[dimension];
            colCount = new int[dimension];
        }

        public virtual Move DecideMove(Board board)
        {
            if(inValidCount==3)
            {
                Console.WriteLine("You have entered more tha nallowed invalid moves");
                return null;
            }
            Console.WriteLine("Enter the row num");
            int row= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the col num");
            int col = Convert.ToInt32(Console.ReadLine());
            var cell = board.board[row][col];
            if (cell.cellState==CellState.FILLED)
            {
                inValidCount++;
                Console.WriteLine("Invalid move");
                return DecideMove(board);
            }
            cell.cellState = CellState.FILLED;
            cell.player = this;
            
            return new Move(cell, this);

        }
    }
}
