using System;
using System.Collections.Generic;
using System.Text;

namespace GameManager
{
    public class GamesCatalog
    {
        public Dictionary<int, string> AllGames
        {
            get
            {
                List<PublishedGame> allGames = new List<PublishedGame>();

                //initialize data because we do not have a database implemented yet
                GameManager.PublishedGame newGame = new GameManager.PublishedGame();
                newGame.GameName = "DiceGame";
                newGame.GameType = "Dice";
                newGame.GameOdds = 0.93;
                allGames.Add(newGame);

                GameManager.PublishedGame newGame2 = new GameManager.PublishedGame();
                newGame2.GameName = "CardGame";
                newGame2.GameType = "Cards";
                newGame2.GameOdds = 0.95;
                allGames.Add(newGame2);
                
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


    }
}
