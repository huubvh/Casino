using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChannelCLI
{
    class CLIPlayDiceGame
    {

        public bool PlayDiceGame(TheHouse.Player player, DiceGame.DiceGame currentGame)
        {

            Console.WriteLine(currentGame.GameSummary());
            currentGame.diceAmount = 3;
            currentGame.diceType = 6;

            //bet
            currentGame.bet = PlaceBet(player);

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
                return true;
            }
            else
            {
                return false;
            }

        }

        int PlaceBet(TheHouse.Player player)
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
                PlaceBet(player);
            }
            return 0;

        }
    }
}
