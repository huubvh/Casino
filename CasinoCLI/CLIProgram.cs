using System;



namespace PlayChannelCLI
{
    class PlayseatCLI
    {
        bool keepPlaying = true;
        TheHouse.Player player = new TheHouse.Player();
        TheHouse.GamesCatalog catalog = new TheHouse.GamesCatalog();
        bool validatedInput = false;
        int selectedGame;
        bool gameExists = false;



        public void Run( Program.ConsolePlayerInterface io)
        {
            // post welcome message
            string welcomeMessage = TheHouse.WelcomeDesk.Welcome();
            
            io.DisplayMessage(welcomeMessage);

            player.Credits = 100;

            // get available games
            foreach (var item in catalog.AllGames)
            {
                io.DisplayMessage("For " + item.Value + " press " + item.Key);
            }

            // fill the catalog with games, but this is not yet necessary

            UserSelectGame(io);
            
            //start selected game
            while (keepPlaying)
            {
                StartGame(selectedGame,io);    
            }

            io.DisplayMessage("Thanks for Playing!");
            Environment.Exit(2);
            
        }

        void UserSelectGame(Program.ConsolePlayerInterface io)
        {
            //get and validate input
            while (!validatedInput)
            {
                string input = Console.ReadLine();
                validatedInput = ValidateInput(input, catalog, io);
            }

        }
        bool ValidateInput(string input, TheHouse.GamesCatalog catalog, Program.ConsolePlayerInterface io)
        {

            validatedInput = ValidateInt(input);
            if (!validatedInput)
            {
                io.DisplayMessage($"'{input}' is not a valid input");
                io.DisplayMessage($"Please try again");
                return false;
            }
            else
            {
                selectedGame = Int32.Parse(input);
                gameExists = catalog.checkGameExistence(catalog, selectedGame);
                if (!gameExists)
                {
                    io.DisplayMessage($"'{input}' does not exist");
                    io.DisplayMessage($"Please try again");
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

        bool StartGame(int selectedGame, Program.ConsolePlayerInterface io)
        {
            switch (selectedGame)
            {
                case 1: 
                    CLIPlayDiceGame diceGame = new CLIPlayDiceGame();
                    keepPlaying = diceGame.PlayDiceGame(player, io);
                    if (!keepPlaying) { return false; }
                    else { return true; }

                default:
                    return false;
            }


        }
        
    }
}
