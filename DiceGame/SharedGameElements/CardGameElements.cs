using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace GameLibrary
{
    
    public enum Suit
    {
        Club = 1,
        Diamond = 2,
        Heart = 3,
        Spades = 4
    }

    public enum CardNumber
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Joker = 14
    }


    public class CardHand
    {
        public List<Card> Cards = new List<Card>();

        public List<Card> AddCard(Card card)
        {
            Cards.Add(card);
            return Cards;
        }

        public string ShowHand()
        {
            string handMessage = "";
            foreach (Card c in Cards)
            {
                handMessage += (c.CardNumber.ToString()) + "/";
            }

            return handMessage;
        }

        public virtual int FaceValue(CardNumber cardNumber)
        {

            int value = 0;
            if ((int)cardNumber > 9)
            {
                value = 10;
            }
            else
            {
                value = (int)cardNumber;
            }
            return value;
        }
        public string DealCard(DeckOfCards deck)
        {
            Card card = deck.TakeCard(); 
            Cards.Add(card);
            string message = card.CardNumber.ToString();
            return message;
        }
    }
 
    public class Card
    {
        public int faceValue;
        public string cardValue;
        public Suit Suit { get; set; }
        public CardNumber CardNumber { get; set; }
        public string CardValue
        { 
            get 
            {
                string value = CardNumber.ToString() + " of " + Suit.ToString();
                return value;
            } 
            set { cardValue = value; } 
        }

    }

    public class DeckOfCards
    {
        public List<Card> Cards { get; set; }
        public DeckOfCards()
        {
            NewDeck();
        }

        public virtual void NewDeck()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                .Select(c => new Card()
                            {
                                Suit = (Suit)s,
                                CardNumber = (CardNumber)c
                            }
                            )
                        )
                 .ToList();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid())
                         .ToList();
        }

        public Card TakeCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        public IEnumerable<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            var takeCards = cards as Card[] ?? cards.ToArray();
            Cards.RemoveAll(takeCards.Contains);

            return takeCards;
        }

        public class DeckOfCardsJokers : DeckOfCards
        {
            
            public override void NewDeck()
            {
                Cards = Enumerable.Range(1, 4)
                    .SelectMany(s => Enumerable.Range(1, 14)
                    .Select(c => new Card()
                    {
                        Suit = (Suit)s,
                        CardNumber = (CardNumber)c
                    }
                                )
                            )
                     .ToList();
            }

        }

    }
}
