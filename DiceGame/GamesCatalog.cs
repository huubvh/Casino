using System;
using System.Collections.Generic;


namespace GameLibrary
{
    public class GamesCatalog
    {

        public GamesCatalog()
        {

        }
        public Dictionary<int, string> GetGamesCatalog
        {
            get
            {
                List<PublishedGame> allGames = new List<PublishedGame>();

                //initialize data because we do not have a database implemented yet
                PublishedGame newGame = new PublishedGame();
                newGame.AddGame("DiceGame", "Dice", 0.93m);
                newGame.GameRules = "Welcome to the Dice Game! \nYou can roll three dice. Make sure you don't roll a pair, or you might lose!";
                allGames.Add(newGame);
                
                PublishedGame newGame2 = new PublishedGame();
                newGame2.AddGame("Poker","Cards",0.95m);
                newGame.GameRules = "Welcome to three card Poker!";
                allGames.Add(newGame2);

                PublishedGame newGame3 = new PublishedGame();
                newGame3.AddGame ("Black Jack", "Cards", 0.95m);
                newGame.GameRules = "Welcome to Black Jack! You can't double or split. Insurance is allowed. Dealer hits on soft 17. Dealer wins on draw";
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

        public bool CheckGameExistence(Dictionary<int, string> gameList, int selectedGame)
        {
            //check if game exists    
            foreach (var item in gameList)
            {
                if (selectedGame == item.Key)
                {
                    return true;
                }
            }
            return false;

        }

    }

    public class PublishedGame :BaseGame
    {
        public DateTime addedToCatalogDate { get; set; }
        

    }

}
