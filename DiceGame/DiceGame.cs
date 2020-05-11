using System;
using System.Collections.Generic;


namespace GameLibrary
{
    public class DiceGame

    {
        public Enums.resultType result;
        public int bet;
        public int win;
        public int pushDie;
        public PlayerTurn playerTurn = new PlayerTurn();

        public int shoveDie;
        public int diceAmount = 3;
        public int diceType = 6;

        public void PlayDiceGame(TheHouse.Player player, TheHouse.IPlayerInterface io)
        {

            GameSummary(io); //static method
            bet = EnterBet(player, io); //function
            Push(io); //method
            PlayerRolls(io, pushDie);

            if (!playerTurn.Win)
            {
                // go to shove
                result = Shove(io);
            }
            else
            {
                //win
                result = Enums.resultType.winDirect;
            }
            io.DisplayMessage(Payout(result,player));
        }


        public static void GameSummary(TheHouse.IPlayerInterface io)
        {

            string gameSummary = ("Welcome to the Dice Game. \nYou can roll three dice. Make sure you don't roll a pair, or you might lose!");
            io.DisplayMessage(gameSummary);
        }


        public int EnterBet(TheHouse.Player player, TheHouse.IPlayerInterface io)
        {
            bool betplaced = false;
            int newBet = 0;
            while (!betplaced)
            {

                io.DisplayMessage($"Your current balance = {player.Credits}");
                io.DisplayMessage("How much do you want to bet?");

                string betAmountString = io.GetInput();

                try
                {
                    newBet = int.Parse(betAmountString);
                    betplaced = true;

                }
                catch (FormatException)
                {
                    io.DisplayMessage($"you have not entered a valid amount");
                }
            }
            return (newBet);
        }

        public void Push(TheHouse.IPlayerInterface io)
        {
            //push
            pushDie = Dice.DiceRoll(diceType);
            string pushMessage = ($"\nThe house has rolled the Push. The Push is a {pushDie}");
            io.DisplayMessage(pushMessage);
        }
        public void PlayerRolls(TheHouse.IPlayerInterface io, int pushDie)
        {

            List<int> currentGameDice = new List<int>();
            currentGameDice.Add(pushDie);

            int loop = 0;
            while (loop < diceAmount)
            {
                io.DisplayMessage("\nPress a key to roll a die");
                io.GetInput();
                int roll = Dice.DiceRoll(diceType);
                io.DisplayMessage("\t\tYou've rolled a " + roll);


                foreach (int i in currentGameDice)
                {
                    if (i == roll)
                    {
                        playerTurn.Pair = i;
                        io.DisplayMessage("With this roll, you have pair of " + roll + "'s. Your turn has ended because you've rolled a pair.");
                        playerTurn.Win = false;
                        playerTurn.Win = false;
                        return;
                    }

                }
                currentGameDice.Add(roll);


                loop++;
            }
            playerTurn.Win = true;
            return;

        }

        public Enums.resultType Shove(TheHouse.IPlayerInterface io)
        {
            shoveDie = Dice.DiceRoll(diceType);
            io.DisplayMessage("\nÝou've got one chance to save yourself!");
            io.DisplayMessage("\nPress a key to roll the die. You have to roll a " + playerTurn.Pair + " to win.");
            io.GetInput();
            io.DisplayMessage("\tYou've rolled a " + shoveDie + "!");

            if (shoveDie == playerTurn.Pair)
            {
                result = Enums.resultType.winShove;

            }
            else
            {
                result = Enums.resultType.lose;
            }

            return(result);
        }

        public string Payout(Enums.resultType result, TheHouse.Player player)
        {
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
            return (message);
        }


    }
    public class PlayerTurn
    {
            
        public List<int> PlayerDice { get; set; }

        public int Pair { get; set; }
        public bool Win { get; set; }
    }


    public class Dice
    {
        public static int DiceRoll(int d)
        {
            Random roll = new Random();
            int dieValue = roll.Next(1, d + 1);
            return dieValue;
        }
    }

    public class Enums
    {
        public enum resultType
        {
            winDirect,
            winShove,
            lose,
        };
    }

    
}
