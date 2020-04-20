﻿using System;


namespace PlayChannelCLI
{
    class PlayseatCLI
    {
        bool keepPlaying = true;
        TheHouse.Player player = new TheHouse.Player();
        DiceGame.DiceGame currentGame = new DiceGame.DiceGame();
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
            GameManager.GamesCatalog catalog = new GameManager.GamesCatalog();
            foreach (var item in catalog.AllGames)
            {
                Console.WriteLine("For " + item.Value + " press " + item.Key);
            }

            //get and validate input
            while (!validatedInput)
            {
                string input = Console.ReadLine();
                validatedInput = ValidateInput(input, catalog);
            }

            //start selected game
            {
                PlayGame(selectedGame);
            } while (keepPlaying)

            Console.WriteLine("Thanks for Playing!");
            Environment.Exit(2);
            
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

        bool PlayGame(int selectedGame)
        {

            switch (selectedGame)
            {
                case 1:
                    keepPlaying = PlayDiceGame(player);
                    if (keepPlaying) { PlayDiceGame(player); }
                    return true;
                case 2:
                    Console.WriteLine("This game has not been implemented.");
                    return false;
                default:
                    {
                        Console.WriteLine("This is not a valid choice");
                        return false;
                    }
            }
        }

        bool PlayDiceGame(TheHouse.Player player)
        {

            Console.WriteLine(currentGame.GameSummary());
            currentGame.diceAmount = 3;
            currentGame.diceType = 6;

            //bet
            currentGame.bet = PlaceBet();

            //push
            string push = currentGame.Push();
            Console.WriteLine(push);

            // playerturns

            currentGame.Game(player);




            // end of game
            Console.WriteLine("\nYour current balance = " + player.Credits);
            Console.WriteLine("\nPress 'p' to play again, press any other key to end the game");

            string input = Console.ReadLine();
            if (input == "p")
            {
                keepPlaying = true;
                return (keepPlaying);
            }
            else
            {
                keepPlaying = false;
                return (keepPlaying);
            }

        }

        int PlaceBet()
        {

            Console.WriteLine("Your current balance = " + player.Credits);
            Console.WriteLine("How much do you want to bet?");

            int betAmount = 0;
            string betAmountString = Console.ReadLine();

            try
            {
                betAmount = int.Parse(betAmountString);
                return (betAmount);
            }
            catch (FormatException)
            {
                Console.WriteLine($"you have not entered a valid amount");
                PlaceBet();
            }
            return 0;

        }



        
    }
}