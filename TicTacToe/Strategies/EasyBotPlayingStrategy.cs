using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Strategies
{
    internal class EasyBotPlayingStrategy:IBotPlayingStrategy
    {
        public Move DecideMove(Player player, Board board)
        {
            for(int i=0;i<board.board.Count;i++)
            {
                for(int j = 0; j < board.board[0].Count;j++)
                {
                    if (board.board[i][j].cellState==CellState.EMPTY)
                    {
                        board.board[i][j].cellState = CellState.FILLED;
                        board.board[i][j].player = player;
                        return new Move(board.board[i][j], player);
                    }
                }
            }
            return null;
        }

       
    }
}
