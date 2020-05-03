using System;
using System.Collections.Generic;
using System.Text;

namespace TheHouse
{
    public class GamesCatalog
    {
        public Dictionary<int, string> AllGames
        {
            get
            {
                List<PublishedGame> allGames = new List<PublishedGame>();

                //initialize data because we do not have a database implemented yet
                PublishedGame newGame = new PublishedGame();
                newGame.GameName = "DiceGame";
                newGame.GameType = "Dice";
                newGame.GameOdds = 0.93;
                allGames.Add(newGame);
                
                PublishedGame newGame2 = new PublishedGame();
                newGame2.GameName = "Poker";
                newGame2.GameType = "Cards";
                newGame2.GameOdds = 0.95;
                allGames.Add(newGame2);

                PublishedGame newGame3 = new PublishedGame();
                newGame3.GameName = "Black Jack";
                newGame3.GameType = "Cards";
                newGame3.GameOdds = 0.95;
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

        public bool checkGameExistence(TheHouse.GamesCatalog gamesCatalog, int selectedGame)
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


    }
}
