using System;
using System.Text;

namespace PlayChannelCLI
{
    class PlayseatCLI
    {
        TheHouse.Player player;
        GameLibrary.GamesCatalog catalog;
        Program.ConsolePlayerInterface io = new Program.ConsolePlayerInterface();

        int selectedGame;
        bool keepPlaying = true;

        public PlayseatCLI(Program.ConsolePlayerInterface newIo)
        {

            io = newIo;
            player = new TheHouse.Player(io);
            catalog = new GameLibrary.GamesCatalog();
        }

        public void Run()
        {
            // post welcome message
            string welcomeMessage = TheHouse.CashiersDesk.Welcome();

            io.DisplayMessage(welcomeMessage);

            player.Credits = 100;


            while (keepPlaying)
            {
                selectedGame = SelectGame();
                keepPlaying = StartGame(selectedGame, player);

            }
            io.DisplayMessage("Thanks for Playing on PlaySeatCLI!");
            Environment.Exit(2);

        }

        public int SelectGame()
        {
            // get available games
            foreach (var item in catalog.GetGamesCatalog)
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
                    
                    if (!catalog.checkGameExistence(catalog.GetGamesCatalog, selectedGame))
                    {
                        io.DisplayMessage($"'{inputString}' does not exist");
                        io.DisplayMessage($"Please try again");
                        validatedInput = false;
                    }
                    else 
                    {
                        validatedInput = true;
                    }
                }

            }
            return(selectedGame);

        }
        
        bool StartGame(int selectedGame, TheHouse.Player player)
        {

            switch (selectedGame)
            {
                case 1:
                    GameLibrary.DiceGame diceGame = new GameLibrary.DiceGame(player, io);
                    
                    string name;
                    catalog.GetGamesCatalog.TryGetValue(selectedGame, out name);
                    diceGame.GameName = name;
                    diceGame.diceAmount = 3;
                    diceGame.diceType = 6;

                    diceGame.PlayDiceGame();
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
                    GameLibrary.PokerGame poker = new GameLibrary.PokerGame(player, io);
                    
                    poker.PlayPoker();
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

    }
}
