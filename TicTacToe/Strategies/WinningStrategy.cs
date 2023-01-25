using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Strategies
{
    internal class WinningStrategy : IWinningStrategy
    {
        public bool IsWinner(Move move, Board board)
        {
            int dimension = board.board.Count;
            var player = move.Player;
            //Update player count
            player.rowCount[move.Cell.row] += 1;
            if(player.rowCount.Length==dimension)
            {
                return true;
            }
            player.colCount[move.Cell.col] += 1;
            if (player.colCount.Length == dimension)
            {
                return true;
            }
            if (move.Cell.col == move.Cell.row)
            {
               player.leftDiag += 1;
            }
            if (player.leftDiag == dimension)
                return true;
            if (move.Cell.row + move.Cell.col == dimension-1)
            {
                player.rightDiag += 1;
            }

            if (player.rightDiag == dimension)
                return true;

            return false;
            
        }
    }
}
