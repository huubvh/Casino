using System;
using System.Collections.Generic;

namespace DiceGame
{
    public class DiceGame

    {
         public Enums.resultType result { get; set; }
         int bet { get; set; }
         int win { get; set; }
         int pushDie { get; set; }
         PlayerTurn playerTurn { get; set; }

         int diceAmount { get; set; }
         int diceType { get; set; }
         int shoveDie { get; set; }


        public void Game(TheHouse.Player player, int diceAmount, int diceType)
        {
            Console.WriteLine("Welcome to the Dice Game. \nYou can roll three dice. Make sure you don't roll a pair, or you might lose!");

            // initialize
            DiceGame currentGame = new DiceGame();
            currentGame.playerTurn = new PlayerTurn();
            currentGame.playerTurn.PlayerDice = new List<int>();
            currentGame.diceAmount = diceAmount;
            currentGame.diceType = diceType;
            currentGame.bet = EnterBet(player);

            //start
            currentGame.pushDie = Dice.DiceRoll(currentGame.diceType);
            Console.WriteLine("\nThe push is " + currentGame.pushDie);

            //players turn
            currentGame.playerTurn = PlayerRolls(currentGame);

            if (currentGame.playerTurn.Result)
            {
                //win
                currentGame.result = Enums.resultType.winDirect;
            }
            else
            {
                // go to shove
                currentGame.result = Shove(currentGame);
            }

            switch (currentGame.result)
            {
                case Enums.resultType.winDirect:
                    currentGame.win = currentGame.bet * 2;
                    Console.WriteLine("You won! Single payout, you win " + currentGame.win + "!");
                    player.Credits += currentGame.win - currentGame.bet;
                    break;
                case Enums.resultType.winShove:
                    currentGame.win = currentGame.bet * 10;
                    player.Credits += currentGame.win - currentGame.bet;
                    Console.WriteLine("You won the Shove! Nine times payout, you win " + currentGame.win + "!");
                    break;
                case Enums.resultType.lose:
                    Console.WriteLine("You have lost, better luck next time");
                    player.Credits -= currentGame.bet;
                    break;
                default:
                    Console.WriteLine("An error has occurred, We cannot determine the outcome of the game.");
                    break;


            }

            Console.WriteLine("\nYour current balance = " + player.Credits);
            Console.WriteLine("\nPress 'p' to play again, press any other key to end the game");
            string input = Console.ReadLine();
            if (input == "p")
            {
                Game(player,3,6);
            }
            else
            {
                Environment.Exit(2);
            }

        }

        public static PlayerTurn PlayerRolls(DiceGame inputGame)
        {
            List<int> currentGameDice = new List<int>();
            currentGameDice.Add(inputGame.pushDie);

            PlayerTurn currentTurn = inputGame.playerTurn;

            int loop = 0;
            while (loop < inputGame.diceAmount)
            {
                Console.WriteLine("\nPress a key to roll a die");
                Console.ReadKey();
                int roll = Dice.DiceRoll(inputGame.diceType);
                Console.WriteLine("\t\tYou've rolled a " + roll);
                currentTurn.PlayerDice.Add(roll);

                foreach (int i in currentGameDice)
                {
                    if (i == roll)
                    {
                        currentTurn.pair = i;
                        Console.WriteLine("With this roll, you have pair of " + roll + "'s. Your turn has ended");
                        inputGame.playerTurn.Result = false;
                        currentTurn.Result = false;
                        return (currentTurn);
                    }

                }
                currentGameDice.Add(roll);


                loop++;
            }
            currentTurn.Result = true;
            return currentTurn;

        }

        public static Enums.resultType Shove(DiceGame inputGame)
        {
            DiceGame shove = new DiceGame();
            shove.shoveDie = Dice.DiceRoll(inputGame.diceType);
            Console.WriteLine("\nÝou've got one chance to save yourself!");
            Console.WriteLine("\nPress a key to roll the die. You have to roll a " + inputGame.playerTurn.pair + " to win.");
            Console.ReadKey();
            Console.WriteLine("\tYou've rolled a " + shove.shoveDie + "!");

            if (shove.shoveDie == inputGame.playerTurn.pair)
            {
                shove.result = Enums.resultType.winShove;

            }
            else
            {
                shove.result = Enums.resultType.lose;
            }

            return shove.result;
        }

        public static int EnterBet(TheHouse.Player player)
        {
            int betAmount = 0;
            Console.WriteLine("Your current balance = " + player.Credits);
            Console.WriteLine("How much do you want to bet?");
            string betAmountString = Console.ReadLine();

            try
            {
                betAmount = int.Parse(betAmountString);
            }
            catch (FormatException)
            {
                Console.WriteLine($"you have not entered a valid amount");
                EnterBet(player);
            }

            return (betAmount);

        }
    }
}
