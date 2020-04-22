using System;


namespace PlayChannelCLI
{
    class PlayseatCLI
    {
        bool keepPlaying = true;
        TheHouse.Player player = new TheHouse.Player();
        DiceGame.DiceGame currentGame = new DiceGame.DiceGame();
        GameManager.GamesCatalog catalog = new GameManager.GamesCatalog();
        bool validatedInput = false;
        int selectedGame;
        bool gameExists = false;

        public void Run()
        {
            // post welcome message
            string welcomeMessage = TheHouse.WelcomeDesk.Welcome();
            Console.WriteLine(welcomeMessage);

            player.Credits = 100;

            // get available games
            foreach (var item in catalog.AllGames)
            {
                Console.WriteLine("For " + item.Value + " press " + item.Key);
            }

            // fill the catalog with games, but this is not yet necessary

            UserSelectGame();
            
            //start selected game
            while (keepPlaying)
            {
                StartGame(selectedGame);    
            } 

            Console.WriteLine("Thanks for Playing!");
            Environment.Exit(2);
            
        }

        void UserSelectGame()
        {
            //get and validate input
            while (!validatedInput)
            {
                string input = Console.ReadLine();
                validatedInput = ValidateInput(input, catalog);
            }

        }
        bool ValidateInput(string input, GameManager.GamesCatalog catalog)
        {

            validatedInput = ValidateInt(input);
            if (!validatedInput)
            {
                Console.WriteLine($"'{input}' is not a valid input");
                Console.WriteLine($"Please try again");
                return false;
            }
            else
            {
                selectedGame = Int32.Parse(input);
                gameExists = currentGame.checkGameExistence(catalog, selectedGame);
                if (!gameExists)
                {
                    Console.WriteLine($"'{input}' is not a valid input");
                    Console.WriteLine($"Please try again");
                    return false;
                }
                else { return true; }
            }
        }

        bool ValidateInt(string input)
        {
            //validate and return input
            int inputInt = 0;
            if (!int.TryParse(input, out inputInt))
            {
                return false;
            }
            return true;           
        }

        bool StartGame(int selectedGame)
        {
            CLIPlayDiceGame diceGame = new CLIPlayDiceGame();

            keepPlaying = diceGame.PlayDiceGame(player, currentGame);
            if (!keepPlaying) { return false; }
            else { return true; }

        }
        
    }
}
