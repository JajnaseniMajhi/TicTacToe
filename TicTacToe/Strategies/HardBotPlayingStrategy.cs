using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Strategies
{
    internal class HardBotPlayingStrategy : IBotPlayingStrategy
    {
        public Move DecideMove(Player player, Board board)
        {
            int rows = board.board.Count;
            int cols = board.board[0].Count;
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if (board.board[i][j].cellState==CellState.EMPTY)
                    {
                        board.board[i][j].cellState = CellState.FILLED;
                        board.board[i][j].player=player;
                        return new Move(board.board[i][j], player);
                    }
                }
            }
            return null;
        }
    }
}
