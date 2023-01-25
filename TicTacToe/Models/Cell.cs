using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class Cell
    {
        public Player player { get; set; }
        public int row { get; set; }

        public int col { get; set; }
        public CellState cellState { get; set; }

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.cellState = CellState.EMPTY;
        }

        //public Player GetPlayer()
        //{
        //    return player;
        //}
    }
}
