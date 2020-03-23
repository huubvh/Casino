using System;
using System.Collections.Generic;

namespace PlayChannelCLI
{
    class PlayseatCLI
    {

       
        public static void Main(string[] args)
        {
            GameManager.GamesCatalog availableGames = new GameManager.GamesCatalog();
            availableGames.AllGames = new List<GameManager.PublishedGame>();
        //initialize data because we do not have a database implemented yet
            GameManager.PublishedGame newGame = new GameManager.PublishedGame();
            newGame.GameName = "DiceGame";
            newGame.GameType = "Dice";
            newGame.GameOdds = 0.93;
            availableGames.AllGames.Add(newGame);

            GameManager.PublishedGame newGame2 = new GameManager.PublishedGame();
            newGame2.GameName = "CardGame";
            newGame2.GameType = "Cards";
            newGame2.GameOdds = 0.95;
            availableGames.AllGames.Add(newGame2);

            Welcome();
            SelectGame(availableGames);
        }

        public static void Welcome()
        {
            string welcomeMessage = TheHouse.WelcomeDesk.Welcome();
            Console.WriteLine(welcomeMessage);
            

        }

        public static void SelectGame(GameManager.GamesCatalog availableGames) {
            //get list of games
            int key = 1;
            var gamesCatalog = new Dictionary<int, string>();
                         
            foreach (var item in availableGames.AllGames)
            {
                gamesCatalog.Add(key,item.GameName);
                key++;
            }

            
            // foreach game in the gamelist print message
            foreach (var item in gamesCatalog)
            {
                Console.WriteLine("For " + item.Value + " press " + item.Key);
                ;
            }
        
            string input = Console.ReadLine();
            int inputInt = 0;
            try
            {
                inputInt = Int16.Parse(input);

            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }

            // todo: add validation to input
            foreach (var item in gamesCatalog)
            {
                if (inputInt == item.Key)
                {

                }
            }

            if (input == "1")
            {
                //play dicegame
                Environment.Exit(1);
            }
            if (input == "2")
            {
                Console.WriteLine("This still needs to be implemented");
                SelectGame(availableGames);
            }
            else
            {
                Console.WriteLine("This is not a valid input");
                SelectGame(availableGames);
            }

        }
    }
}
