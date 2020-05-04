using System;
using System.Collections.Generic;


namespace GameLibrary
{
    public class Poker 
    {
        
        DeckOfCards deck = new DeckOfCards();

       public void PlayPoker(TheHouse.Player player, TheHouse.IPlayerInterface io)
        {
            Poker pokerGame = new Poker();
                        
            deck.Reset();
            deck.Shuffle();

            List<Card> playerHand = new List<Card>();
            List<Card> dealerHand = new List<Card>();
            
            int count = 0;
            while (count < 3)
                {
                Card newCard = deck.TakeCard();
                playerHand.Add(newCard);
                count++;
            }

            count = 0;
            while (count < 3)
            {
                Card newCard = deck.TakeCard();
                dealerHand.Add(newCard);
                count++;
            }

            io.DisplayMessage($"the player has:");
            foreach (Card c in playerHand)
            {
                io.DisplayMessage($"{c.CardNumber} of {c.Suit}");
            }

            io.DisplayMessage($"\nthe dealer has:");
            foreach (Card c in dealerHand)
            {
                io.DisplayMessage($"{c.CardNumber} of {c.Suit}");
            }

            HandValue playerHandValue = CheckForValue(playerHand, io);
            HandValue dealerHandValue = CheckForValue(dealerHand, io);

            io.DisplayMessage($"\nPlayer has a {playerHandValue}");
            io.DisplayMessage($"Dealer has a {dealerHandValue}");

        }

        public HandValue CheckForValue(List<Card> hand, TheHouse.IPlayerInterface io)
        {

            if(hand.Count != 3)
            {
                io.DisplayMessage("We can only check hands containing three cards");
                return (HandValue.Invalid);
            }

            if (hand[0].CardNumber == hand[1].CardNumber && hand[1].CardNumber == hand[2].CardNumber)
            {
                //three of a kind
                return (HandValue.ThreeOfAKind);
            }

            if (hand[0].CardNumber == hand[1].CardNumber || hand[1].CardNumber == hand[2].CardNumber || hand[0].CardNumber == hand[2].CardNumber)
            {
                //pair
                return (HandValue.Pair);
            }


            if (hand[0].Suit == hand[1].Suit && hand[1].Suit == hand[2].Suit)
            {
                //Flush
                return HandValue.Flush;
            }
            else
            {
                //three of a kind
                return (HandValue.HighCard);
            }

        }

        public enum HandValue
        {
            StraightFlush = 1,
            ThreeOfAKind = 2,
            Straight = 3,
            Flush = 4,
            Pair = 5,
            HighCard = 6,
            Invalid = 7

        }

    }
}
