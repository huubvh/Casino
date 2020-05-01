using System;
using System.Collections.Generic;


namespace DiceGame
{
    public class DiceGame

    {
        public Enums.resultType result;
        public int bet;
        public int win; 
        public int pushDie;
        public PlayerTurn playerTurn = new PlayerTurn();
        public int shoveDie;
        public int diceAmount;
        public int diceType;

        // welcome message
        // enter bet
        // display what the push is
        // start playerturns
        // // 
        // display result message


        public string GameSummary()
        {
            string gameSummary = "Welcome to the Dice Game. \nYou can roll three dice. Make sure you don't roll a pair, or you might lose!";
            return (gameSummary);

        }

        public string Push()
        {
            pushDie = Dice.DiceRoll(diceType);
            string pushMessage = "\nThe house has rolled the Push. The Push is a " + pushDie;
            return pushMessage;
        }
        public string Game(TheHouse.Player player)
        {
            // players turn
            playerTurn.Win = PlayerRolls();

            if (!playerTurn.Win )
            {
                // go to shove
                result = Shove();
            }
            else
            {
                //win
                result = Enums.resultType.winDirect;

            }
            string message;
            switch (result)
            {
                case Enums.resultType.winDirect:
                    win = bet * 2;
                    message = ("You won! Single payout, you win " + win + "!");
                    player.Credits += win - bet;
                    break;
                case Enums.resultType.winShove:
                    win = bet * 10;
                    player.Credits += win - bet;
                    message = ("You won the Shove! Nine times payout, you win " + win + "!");
                    break;
                case Enums.resultType.lose:
                    message = ("You have lost, better luck next time");
                    player.Credits -= bet;
                    break;
                default:
                    message = ("An error has occurred, We cannot determine the outcome of the game.");
                    break;

            
            }
            return(message);
            /*
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
            */
        }

        public bool PlayerRolls()
        {
            List<int> currentGameDice = new List<int>();
            currentGameDice.Add(pushDie);

            PlayerTurn currentTurn = playerTurn;
            currentTurn.PlayerDice = new List<int>();

            int loop = 0;
            while (loop < diceAmount)
            {
                Console.WriteLine("\nPress a key to roll a die");
                Console.ReadKey();
                int roll = Dice.DiceRoll(diceType);
                Console.WriteLine("\t\tYou've rolled a " + roll);
                playerTurn.PlayerDice.Add(roll);

                foreach (int i in currentGameDice)
                {
                    if (i == roll)
                    {
                        currentTurn.Pair = i;
                        Console.WriteLine("With this roll, you have pair of " + roll + "'s. Your turn has ended because you've rolled a pair.");
                        playerTurn.Win = false;
                        currentTurn.Win = false;
                        return (currentTurn.Win);
                    }

                }
                currentGameDice.Add(roll);


                loop++;
            }
            currentTurn.Win = true;
            return currentTurn.Win;

        }

        public Enums.resultType Shove()
        {
            shoveDie = Dice.DiceRoll(diceType);
            Console.WriteLine("\nÝou've got one chance to save yourself!");
            Console.WriteLine("\nPress a key to roll the die. You have to roll a " + playerTurn.Pair + " to win.");
            Console.ReadKey();
            Console.WriteLine("\tYou've rolled a " + shoveDie + "!");

            if (shoveDie == playerTurn.Pair)
            {
                result = Enums.resultType.winShove;

            }
            else
            {
                result = Enums.resultType.lose;
            }

            return result;
        }

        public void EnterBet(int playerBet)
        {
            bet = playerBet;
        }

  





    }
}
