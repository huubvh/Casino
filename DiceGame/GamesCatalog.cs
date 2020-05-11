using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class GamesCatalog
    {
        public GamesCatalog()
        {

        }
        public Dictionary<int, string> AllGames
        {
            get
            {
                List<PublishedGame> allGames = new List<PublishedGame>();

                //initialize data because we do not have a database implemented yet
                PublishedGame newGame = new PublishedGame();
                newGame.AddGame("DiceGame", "Dice", 0.93);
                allGames.Add(newGame);
                
                PublishedGame newGame2 = new PublishedGame();
                newGame2.AddGame("Poker","Cards",0.95);
                allGames.Add(newGame2);

                PublishedGame newGame3 = new PublishedGame();
                newGame3.AddGame ("Black Jack", "Cards", 0.95);
                allGames.Add(newGame3);

                int key = 1;
                var gamesCatalog = new Dictionary<int, string>();

                foreach (var item in allGames)
                {
                    gamesCatalog.Add(key, item.GameName);
                    key++;
                }
                return gamesCatalog;

            }
        }

        public bool checkGameExistence(GamesCatalog gamesCatalog, int selectedGame)
        {
            //check if game exists    
            foreach (var item in gamesCatalog.AllGames)
            {
                if (selectedGame == item.Key)
                {
                    return true;
                }
            }
            return false;

        }

    }
    public class PublishedGame
    {
        public string GameName { get; set; }
        public string GameType { get; set; }
        public double GameOdds { get; set; }

        public void AddGame(string newGameName, string newGameType, double newGameOdds)
        {
            GameName = newGameName;
            GameType = newGameType;
            GameOdds = newGameOdds;
                
        }
    }
}
