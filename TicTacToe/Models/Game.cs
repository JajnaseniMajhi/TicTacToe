using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Strategies;

namespace TicTacToe.Models
{
    internal class Game
    {
        private Board board;
        public List<Move> Moves { get; set; }

        public List<Player> PlayersList { get; set; }

        private IWinningStrategy _winningStrategy;
        private int playerIndex;

        private Game()
        {

        }

        public static Builder GetBuilder()
        {
            return new Builder();
        }
        public bool UnDo()
        {
            return true;
        }

        public void PlayNextMove(Player player)
        {
            if(Moves.Count==board.board.Count* board.board.Count)
            {
                Console.WriteLine("All Cells are filled");
                Console.WriteLine("Match is draw.");
                //return false;
            }
            //Decide the move
            var move=  player.DecideMove(board);
            //Add move to moveList
            Moves.Add(move);
            //Check Winner
            if(_winningStrategy.IsWinner(move,board))
            {
                Console.WriteLine("Winner is : " + move.Player.Name);
               // return false;
            }
            playerIndex++;
            if(playerIndex==PlayersList.Count-1)
            {
                playerIndex = 0;
            }
            PlayNextMove(PlayersList[playerIndex]);
            
            //return false;
        }

        public bool CheckWinner(Board board,Move move)
        {
            return _winningStrategy.IsWinner(move, board);
        }

        public  class Builder
        {
            private  int dimension;
            private List<Player> playersList;
            public Builder SetDimension(int dimension)
            {
                this.dimension = dimension;
                return this;
            }

            public Builder SetPlayersList(List<Player> players)
            {
                this.playersList = players;
                return this;
            }

            //Validate

            private bool Valid()
            {
                if(this.dimension<3)
                {
                    throw new Exception("Dimension can not be <3");
                }
                if(playersList.Count!=this.dimension-1)
                {
                    throw new Exception("Players count not matching");
                }
                return true;
            }

            public Game Build()
            {
                try
                {
                    Valid();

                }
                catch (Exception)
                {

                    throw new Exception("Game can not be created");
                }

                Game game = new Game();
                game.board = new Board(dimension);
                game.PlayersList = playersList;
                game._winningStrategy = new WinningStrategy();
                game.playerIndex = 0;
                game.Moves = new List<Move>();
                return game;
            }
           
        }
    }
}
