﻿using System;

namespace PlayChannelCLI
{
    class PlayseatCLI
    {
        bool keepPlaying = true;
        TheHouse.Player player = new TheHouse.Player();
        TheHouse.GamesCatalog catalog = new TheHouse.GamesCatalog();
        int selectedGame;
        bool gameExists = false;



        public void Run(Program.ConsolePlayerInterface io)
        {
            // post welcome message
            string welcomeMessage = TheHouse.WelcomeDesk.Welcome();

            io.DisplayMessage(welcomeMessage);

            player.Credits = 100;


            while (keepPlaying)
            {
                Play(io);

            }
            io.DisplayMessage("Thanks for Playing!");
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

        public bool StartGame(int selectedGame, TheHouse.Player player, Program.ConsolePlayerInterface io)
        {

            switch (selectedGame)
            {
                case 1:
                    DiceGame.DiceGame diceGame = new DiceGame.DiceGame();
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
                    io.DisplayMessage($"This game has not yet been implemented");
                    return true;
                case 3:
                    io.DisplayMessage($"This game has not yet been implemented");
                    return true;

                default:
                    return false;
            }


        }

    }
}
