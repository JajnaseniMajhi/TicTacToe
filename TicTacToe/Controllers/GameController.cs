using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    internal class GameController
    {

        public Game createGame(int dimension, List<Player> players)
        {
            try
            {
                return Game.GetBuilder().SetDimension(dimension)
                                        .SetPlayersList(players)
                                        .Build();
                        
                      
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught:" + e.Message);
                return null;
            }
        }

        public void DisplayBoard(Game game)
        {
            game.DisplayBoard();
        }

        public void NextPlayerMove(Game game)
        {
            game.PlayNextMove();
        }
        public GameStatus GetGameStatus(Game game)
        {
            return game.GameStatus;
        }

        public void Undo(Game game)
        {
            game.UnDo();
        }
    }
}
