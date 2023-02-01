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

        public GameStatus GameStatus { get; set; }

        private Game()
        {
            this.GameStatus = GameStatus.INPROGRESS;
        }

        public static Builder GetBuilder()
        {
            return new Builder();
        }
        public void UnDo()
        {
            int count = Moves.Count;
            if(count > 0)
            {
                    Move lastMove= Moves[count-1];
                
                    Moves.Remove(lastMove);
                    //Update the board
                    Cell cell = lastMove.Cell;
                    board.board[cell.row][cell.col].cellState = CellState.EMPTY;
                    board.board[cell.row][cell.col].player = null;
            }
            else
            {
                Console.WriteLine("No Earlier moves for Undo");
            }
            
        }

        public void DisplayBoard()
        {
            board.DisplayBoard();
        }

        public void PlayNextMove()
        {
            Player player = PlayersList[playerIndex];
            
            if(Moves.Count==board.board.Count* board.board.Count)
            {
                Console.WriteLine("All Cells are filled");
                Console.WriteLine("Match is draw.");
                this.GameStatus = GameStatus.ENDED;
            }
            //Decide the move
            Console.WriteLine("Player {0} is playing", player.Name);
            var move=  player.DecideMove(board);
            if (move != null)
            {
                //Add move to moveList
                Moves.Add(move);
                //Check Winner
                if (_winningStrategy.IsWinner(move, board))
                {
                    DisplayBoard();
                    Console.WriteLine("Winner is : " + move.Player.Name);
                    this.GameStatus = GameStatus.ENDED;
                }
            }
            playerIndex++;
            playerIndex %= PlayersList.Count;
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
