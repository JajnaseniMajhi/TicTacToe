using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;
using TicTacToe.Strategies;

namespace TicTacToe.Factories
{
    internal class BotPlayingFactory
    {
        public static IBotPlayingStrategy GetPlayingStrategy(BotDifficultyLevel difficultyLevel)
        {
            switch(difficultyLevel)
            {
                case BotDifficultyLevel.HARD:
                    return new HardBotPlayingStrategy();
                case BotDifficultyLevel.MEDIUM:
                    return new MediumBotPlayingStrategy();
                case BotDifficultyLevel.EASY:
                    return new EasyBotPlayingStrategy();
            }
            return null;
        }
    }
}
