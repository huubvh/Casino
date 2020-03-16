using System;
using System.Collections.Generic;

namespace PlayChannelCLI
{
    class PlayseatCLI
    {
        public static GameManager.GamesCatalog availableGames = new GameManager.GamesCatalog();

        static void Main(string[] args)
        {
            //initialize data because we do not have a database implemented
            GameManager.PublishedGame newGame = new GameManager.PublishedGame();
            newGame.GameName = "DiceGame";
            newGame.GameType = "Dice";
            newGame.GameOdds = 0.93;
            availableGames.AllGames.Add(newGame);
            
            newGame.GameName = "CardGame";
            newGame.GameType = "Cards";
            newGame.GameOdds = 0.95;
            availableGames.AllGames.Add(newGame);

            Welcome();
        }

        public static void Welcome()
        {
            string welcomeMessage = TheHouse.WelcomeDesk.Welcome();
            Console.WriteLine(welcomeMessage);
            SelectGame();

        }

        public static void SelectGame() {
            //get list of games
            int key = 1;
            var gamesCatalog = new Dictionary<int, GameManager.PublishedGame>();
                         
            foreach (var item in availableGames.AllGames)
            {
                gamesCatalog.Add(key,item);
                key++;
            }

            
            
            
            // foreach game in the gamelist print message
            foreach (var item in gamesCatalog)
            {
                Console.WriteLine("For " + item.Value + "press " + item.Key);
                ;
            }
        
            string input = Console.ReadLine();
            if (input == "d" || input == "D")
            {
               //play dicegame
            }
            if (input == "c" || input == "C")
            {
                Console.WriteLine("This still needs to be implemented");
                Welcome();
            }
            else
            {
                Environment.Exit(1);
            }

        }
    }
}
