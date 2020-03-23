using System;
using System.Collections.Generic;

namespace PlayChannelCLI
{
    class PlayseatCLI
    {

       
        public static void Main(string[] args)
        {
            //get list of available games
           
            GameManager.GamesCatalog catalog = new GameManager.GamesCatalog();
            
            //post welcome message
            Welcome();

            //start 
            SelectGame(catalog);
        }

        public static void Welcome()
        {
            string welcomeMessage = TheHouse.WelcomeDesk.Welcome();
            Console.WriteLine(welcomeMessage);
            

        }

        public static void SelectGame(GameManager.GamesCatalog catalog) {
                       

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
                DiceGame.DiceGame result = new DiceGame.DiceGame();
                Console.WriteLine(result.GameResult);
         
                
            }
            else if (input == "2")
            {
                Console.WriteLine("This still needs to be implemented");
                SelectGame(catalog);
            }
            else
            {
                Console.WriteLine("This is not a valid input");
                SelectGame(catalog);
            }


        }

    }
}
