using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Strategies
{
    internal interface IBotPlayingStrategy
    {
        Move DecideMove(Player player, Board board);
    }
}
