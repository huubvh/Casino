using System;
using System.Collections.Generic;
using TheHouse;

namespace GameLibrary
{

    public class DiceGame : PublishedGame

    {
        public Enums.resultType result;
        public int win;
        public int pushDie;
        public PlayerTurn playerTurn = new PlayerTurn();
        public int shoveDie;
        public int diceAmount;
        public int diceType;


        public DiceGame(Player newPlayer, IUserInterface newIo)
        {
            player = newPlayer;
            io = newIo;
        }

        public void PlayDiceGame()
        {

            GameRules = "Welcome to the Dice Game! \nYou can roll three dice. Make sure you don't roll a pair, or you might lose!";

            GameSummary();
            Bet = player.PlaceBet(); //function
            Push(); //method
            PlayerRolls(pushDie);

            if (!playerTurn.Win)
            {
                // go to shove
                result = Shove(); //function
            }
            else
            {
                //win
                result = Enums.resultType.winDirect;
            }

            switch (result)
            {
                case Enums.resultType.winDirect:
                    player.Payout(Bet, 2);
                    break;
                case Enums.resultType.winShove:
                    player.Payout(Bet, 10);
                    break;
                case Enums.resultType.lose:
                    player.Payout();
                    break;
                default:
                    break;


            }
        }





        public void Push()
        {
            //push
            pushDie = Dice.DiceRoll(diceType);
            string pushMessage = ($"\nThe house has rolled the Push. The Push is a {pushDie}");
            io.DisplayMessage(pushMessage);
        }

        public void PlayerRolls(int pushDie)
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

        public Enums.resultType Shove()
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


    }
    public class PlayerTurn
    {
        public int Pair { get; set; }
        public bool Win { get; set; }
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
