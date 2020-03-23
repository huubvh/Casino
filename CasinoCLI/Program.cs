using System;
using System.Collections.Generic;

namespace PlayChannelCLI
{
    class PlayseatCLI
    {

       
        public static void Main(string[] args)
        {

            //post welcome message
            Welcome();
            TheHouse.Player player = new TheHouse.Player();
            player.Credits = 100;
            //start 
            SelectGame(player);
        }

        public static void Welcome()
        {
            string welcomeMessage = TheHouse.WelcomeDesk.Welcome();
            Console.WriteLine(welcomeMessage);
            

        }

        public static void SelectGame(TheHouse.Player player) {
            //get list of available games

            GameManager.GamesCatalog catalog = new GameManager.GamesCatalog();


            // foreach game in the gamelist print message
            foreach (var item in catalog.AllGames)
            {
                Console.WriteLine("For " + item.Value + " press " + item.Key);
                ;
            }

            // let the player choose which game to play        
            string input = Console.ReadLine();

                //validate input
            int inputInt = 0;
            try
            {
                inputInt = Int16.Parse(input);

            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            foreach (var item in catalog.AllGames)
            {
                if (inputInt == item.Key)
                {

                }
            }

            //start game
            if (input == "1")
            {
                DiceGame.DiceGame currentGame = new DiceGame.DiceGame();
                currentGame.Game(player,3,6);

                Console.WriteLine(currentGame.result);
         
                
            }
            else if (input == "2")
            {
                Console.WriteLine("This still needs to be implemented");
                SelectGame(player);
            }
            else
            {
                Console.WriteLine("This is not a valid input");
                SelectGame(player);
            }


        }

    }
}
