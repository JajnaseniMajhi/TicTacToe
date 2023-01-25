using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class Move
    {
        public Cell Cell { get; set; }

        public Player Player { get; set; }

        public Move(Cell cell, Player player)
        {
            Cell = cell;
            Player = player;
        }
    }
}
