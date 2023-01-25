using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Factories;
using TicTacToe.Strategies;

namespace TicTacToe.Models
{
    internal class Bot : Player
    {

        private BotDifficultyLevel botDifficultyLevel;
        private IBotPlayingStrategy botPlayingStrategy;

        public Bot(int id, string name,string symbol, BotDifficultyLevel difficultyLevel,int dimension) : base(id, name, PlayerType.BOT, symbol,dimension)
        {
            botDifficultyLevel = difficultyLevel;
            botPlayingStrategy = BotPlayingFactory.GetPlayingStrategy(botDifficultyLevel);
        }
       public override Move DecideMove(Board board)
        {
            return botPlayingStrategy.DecideMove(this, board);
        }


    }
}
