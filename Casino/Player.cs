using System;


namespace TheHouse
{
    public class Player
    {
        //keep track of player credits
        public string Name { get; set; }
        public decimal Credits { get; set; }

        public IUserInterface io;

        public Player(IUserInterface newIo)
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
            Credits = Credits - newBet;
            return (newBet);
        }

        public void Payout(int bet, decimal winFactor)
        {
            decimal win = bet * winFactor;
            Credits = Credits + (win);
            string message = ($"You won! You win {win} !");
            io.DisplayMessage(message);
        }
        public void Payout(int bet)
        {
            Credits = Credits + (bet);
            string message = ($"It's a draw, you get {bet} back!");
            io.DisplayMessage(message);
        }
        public void Payout ()
        { 
            string message = ($"You have lost, better luck next time");
            io.DisplayMessage(message);
        }
    }

}
