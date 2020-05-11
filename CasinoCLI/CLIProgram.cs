using System;
using System.Text;

namespace PlayChannelCLI
{
    class PlayseatCLI
    {
        bool keepPlaying = true;
        TheHouse.Player player = new TheHouse.Player();
        GameLibrary.GamesCatalog catalog = new GameLibrary.GamesCatalog();
        int selectedGame;
        bool gameExists = false;
        

        public void Run(Program.ConsolePlayerInterface io)
        {
            // post welcome message
            string welcomeMessage = TheHouse.CashiersDesk.Welcome();

            io.DisplayMessage(welcomeMessage);

            player.Credits = 100;


            while (keepPlaying)
            {
                Play(io);

            }
            io.DisplayMessage("Thanks for Playing on PlaySeatCLI!");
            Environment.Exit(2);

        }

        public void Play(Program.ConsolePlayerInterface io)
        {
            // get available games
            foreach (var item in catalog.AllGames)
            {
                io.DisplayMessage("For " + item.Value + " press " + item.Key);
            }

            // fill the catalog with games, but this is not yet necessary


            //get and validate input
            bool validatedInput = false;
            while (!validatedInput)
            {
                string inputString = io.GetInput();
                ValidateInt(inputString);

                validatedInput = ValidateInt(inputString);
                if (!validatedInput)
                {
                    io.DisplayMessage($"'{inputString}' is not a valid input");
                    io.DisplayMessage($"Please try again");
                    
                }
                else
                {
                    selectedGame = Int32.Parse(inputString);
                    gameExists = catalog.checkGameExistence(catalog, selectedGame);
                    if (!gameExists)
                    {
                        io.DisplayMessage($"'{inputString}' does not exist");
                        io.DisplayMessage($"Please try again");
                        validatedInput = false;
                    }
                    else 
                    {
                        keepPlaying = StartGame(selectedGame, player, io);

                    }
                }

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

        bool StartGame(int selectedGame, TheHouse.Player player, Program.ConsolePlayerInterface io)
        {

            switch (selectedGame)
            {
                case 1:
                    GameLibrary.DiceGame diceGame = new GameLibrary.DiceGame();

                    diceGame.PlayDiceGame(player, io);
                    // end of game
                    io.DisplayMessage("\nYour current balance = " + player.Credits);
                    io.DisplayMessage("\nPress 'p' to play again, press any other key to end the game");

                    string input = io.GetInput();
                    if (input == "p")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    GameLibrary.Poker poker = new GameLibrary.Poker();
                    poker.PlayPoker(player, io);
                    io.DisplayMessage("\nPress 'p' to play again, press any other key to end the game");

                    input = io.GetInput();
                    if (input == "p")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                case 3:
                    io.DisplayMessage($"This game has not yet been implemented");
                    return true;

                default:
                    return false;
            }


        }

    }
}
