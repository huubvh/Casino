using System;
using System.Collections.Generic;
using System.Text;

namespace TheHouse
{
    public class Player
    {
        //keep track of player credits
        public string Name { get; set; }
        public double Credits { get; set; }

        public TheHouse.IPlayerInterface io;

        public Player(TheHouse.IPlayerInterface newIo)
        {
            io = newIo;
        }


        public int PlaceBet()
        {
            bool betplaced = false;
            int newBet = 0;
            while (!betplaced)
            {

                io.DisplayMessage($"Your current balance = {Credits}");
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
    }

}
