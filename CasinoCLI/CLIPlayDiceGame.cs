using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChannelCLI
{
    class CLIPlayDiceGame
    {

        public bool PlayDiceGame(TheHouse.Player player, Program.ConsolePlayerInterface io)
        {
            DiceGame.DiceGame currentGame = new DiceGame.DiceGame();

            Console.WriteLine(currentGame.GameSummary());
            currentGame.diceAmount = 3;
            currentGame.diceType = 6;

            //bet
            bool betplaced = false;
            while (!betplaced)
            {

                io.DisplayMessage("Your current balance = " + player.Credits);
                io.DisplayMessage("How much do you want to bet?");

                string betAmountString = io.GetInput();

                try
                {
                    currentGame.bet = int.Parse(betAmountString);
                    betplaced = true;
                }
                catch (FormatException)
                {
                    io.DisplayMessage($"you have not entered a valid amount");
                }
            }

            //push
            string push = currentGame.Push();
            io.DisplayMessage(push);

            // playerturns
            string result = currentGame.Game(player);
            io.DisplayMessage(result);

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
        }
    }
}
