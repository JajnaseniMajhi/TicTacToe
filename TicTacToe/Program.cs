// See https://aka.ms/new-console-template for more information
using TicTacToe.Controllers;
using TicTacToe.Models;

Console.WriteLine("Hello, World!");
Console.WriteLine("Please Enter the dimension");
int dimension = Convert.ToInt32(Console.ReadLine());
GameController gameController = new GameController();
Console.WriteLine("Is there any Bot playing? Y/N");
string isBotPlayer = Console.ReadLine();
//Make PlayerList

List<Player> playerList = new List<Player>();
int toIterate = dimension - 1;

if(isBotPlayer=="Y")
{
    toIterate = dimension - 2;
}
for(int i=0;i<toIterate;i++)
{
    Console.WriteLine("Please Enter Player Name:");
    string name = Console.ReadLine();
    Console.WriteLine("Please Enter Player symbol:");
    string symbol = Console.ReadLine();
    playerList.Add(new Player(i, name, PlayerType.HUMAN,symbol, dimension));

}
if (isBotPlayer == "Y")
    {
        
    Console.WriteLine("What is the name of the bot");
    string botName = Console.ReadLine();

    Console.WriteLine("What is the character of the bot?");
    string botChar = Console.ReadLine();

    playerList.Add(new Bot(dimension-3,botName,botChar,BotDifficultyLevel.EASY,dimension));
}

    //Start the game

    Game game = gameController.createGame(dimension, playerList);
//playGame

while (game.GameStatus == GameStatus.INPROGRESS)
{
    Console.WriteLine("Display the current board");
    gameController.DisplayBoard(game);

    //Console.WriteLine("Do you want to do UNDO? Y/N");
    //string isUndo = Console.ReadLine();
    //if(isUndo=="Y")
    //{
    //    gameController.Undo(game);
        //gameController.DisplayBoard(game);
    //}
    //else
    //{
       gameController.NextPlayerMove(game);

    //}

}

