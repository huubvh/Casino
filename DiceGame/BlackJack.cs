using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary
{
    public class BlackJack : BaseGame
    {
        private DeckOfCards deck = new DeckOfCards();
        private BjHand playerHand = new BjHand();
        private BjHand dealerHand = new BjHand();
        public Result? GameResult = null;

        public BlackJack(TheHouse.Player newPlayer, TheHouse.IUserInterface newIo)
        {
            player = newPlayer;
            io = newIo;
        }

        public void PlayBlackJack()
        {
            GameRules = "Welcome to Black Jack! \n\tYou can't double or split. \n\tDealer hits on soft 17. \n\tDealer wins on draw. \n\tPlayer blackjack pays out immediately.";
            GameSummary();
            Bet = player.PlaceBet();

            Deal();
            if (GameResult != null)
            {
                EndGame();
            }
            System.Threading.Thread.Sleep(1000);
            Hit();
            if (GameResult != null)
            {
                EndGame();
                return;
            }
            System.Threading.Thread.Sleep(1000);
            DealerHit();
            System.Threading.Thread.Sleep(1000);
            EndGame();


        }

        public void Deal()
        {
            deck.NewDeck();
            deck.Shuffle();

            playerHand.AddCard(deck.TakeCard());
            dealerHand.AddCard(deck.TakeCard());
            playerHand.AddCard(deck.TakeCard());
            dealerHand.AddCard(deck.TakeCard());

            dealerHand.CheckFor21();
            playerHand.CheckFor21();
            if (playerHand.BlackJack)
            {
                GameResult = Result.BlackJack;
                return;
            }

            playerHand.CheckHandValue();
            io.DisplayMessage($"Your cards are: {playerHand.ShowHand()}");
            io.DisplayMessage($"Your total is {playerHand.Total}");

            if (dealerHand.BlackJack)
            {
                io.DisplayMessage($"Dealer has BlackJack!");
                GameResult = Result.DealerWin;
                return;

            }
            else
            {
                io.DisplayMessage($"The dealer has a {dealerHand.Cards[0].CardNumber}");
            }


            
        }

        public void Hit()
        {
            while (!playerHand.Stand && !playerHand.Busted)
            {
                io.DisplayMessage($"Do you want another card?");
                io.DisplayMessage($"Hit = H");
                io.DisplayMessage($"Stand = S");
                string input = io.GetInput();
                if (input == "H" || input == "h")
                {
                    string message = playerHand.DealCard(deck);
                    io.DisplayMessage($"You have drawn a {message}");
                    playerHand.CheckHandValue();
                    playerHand.CheckFor21();
                    io.DisplayMessage($"Your cards are:  ={playerHand.ShowHand()}");
                    io.DisplayMessage($"Your total is {playerHand.Total}");
                    
                }
                else if (input == "S" || input == "s")
                {
                    playerHand.Stand = true;

                }
                else
                {
                    io.DisplayMessage($"{input} is not a valid choice");
                }

            } 

            if (playerHand.Busted)
            {
                io.DisplayMessage($"It's a bust");
                GameResult = Result.DealerWin;
                return;
            }
            return;

        }

        public void DealerHit()
        {
            dealerHand.CheckHandValue();
            dealerHand.CheckDealerStand();
            io.DisplayMessage($"Dealer's cards are:  ={dealerHand.ShowHand()}");
            System.Threading.Thread.Sleep(1000);
            while (!dealerHand.Stand && !dealerHand.Busted)
            {
                string message = dealerHand.DealCard(deck);
                io.DisplayMessage($"Dealer has drawn a {message}");
                dealerHand.CheckHandValue();
                dealerHand.CheckDealerStand();
                io.DisplayMessage($"Dealer's cards are:  ={dealerHand.ShowHand()}");
                io.DisplayMessage($"Dealer's total is {dealerHand.Total}.");
                System.Threading.Thread.Sleep(1000);
            }
            if (dealerHand.Busted)
            {
                GameResult = Result.PlayerWin;
                return;
            }
            return;
        }

        public void EndGame()
        {
            if(GameResult == null)
            {
                io.DisplayMessage($"You have {playerHand.Total} and Dealer has {dealerHand.Total}");
                if (playerHand.Total == dealerHand.Total) { GameResult = Result.Draw; }
                else if (playerHand.Total > dealerHand.Total) { GameResult = Result.PlayerWin; }
                else { GameResult = Result.DealerWin; }
            }

            switch (GameResult)
            {
                case Result.BlackJack:
                    io.DisplayMessage($"You have Blackjack!");
                    player.Payout(Bet, 3);
                    break;
                case Result.DealerWin:
                    player.Payout();
                    break;
                case Result.PlayerWin:
                    player.Payout(Bet, 2);
                    break;
                case Result.Draw:
                    player.Payout(Bet);
                    break;
                default:
                    break;
            }
        }
    }
    public class BjHand : CardHand
    {
        public bool Soft = false;
        public int Total = 0;
        public bool Insurance = false;
        public bool Stand = false;
        public bool Busted = false;
        public bool BlackJack = false;
        public void Hit()
        {

        }

        public void CheckHandValue()
        {
            Total = 0;
            foreach (Card c in Cards)
            {
                Total += FaceValue(c.CardNumber);
            }
            if (Cards.Any(item => item.CardNumber == CardNumber.Ace))
            {
                Soft = true;

            }

            if (Soft && Total > 21) { Total -= 10; }

            if (Total > 21)
            {
                Busted = true;
            }
        }

        public void CheckFor21()
        {
            if (Total == 21)
            {
                Stand = true;
                BlackJack = true;
            }
        }

        public void CheckDealerStand()
        {
            if (Total >= 17 || Soft && Total > 17)
            {
                Stand = true;
            }
        }

        public override int FaceValue(CardNumber cardNumber)
        {

            int value = 0;
            if ((int)cardNumber > 9)
            {
                value = 10;
            }
            else if (cardNumber.Equals(CardNumber.Ace))
            {
                value = 11;
            }
            else
            {
                value = (int)cardNumber;
            }
            return value;
        }


    }

    public enum Result
    {
        PlayerWin = 1,
        Draw = 2,
        DealerWin = 3,
        BlackJack = 4
    }
}
