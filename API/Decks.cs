using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger.Api
{
    internal static class Decks
    {
        internal static Deck Standard { get; set; } = new Deck()
        {
            Cards = new Stack<Card>()
        };

        static Decks()
        {
            // Spades.
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Ace, 5));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Two));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Three));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Four));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Five));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Six));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Seven));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Eight));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Nine));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Ten, 10));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Jack, 15));    // Big gold digger.
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.Queen, 2));
            Standard.Cards.Push(new Card(Suits.Spades, Ranks.King, 3));

            // Harts.
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Ace, 5));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Two));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Three));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Four));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Five));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Six));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Seven));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Eight));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Nine));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Ten, 10));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Jack, 11));     // Gold digger.
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.Queen, 2));
            Standard.Cards.Push(new Card(Suits.Hearts, Ranks.King, 3));

            // Diamonds.
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Ace, 5));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Two));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Three));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Four));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Five));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Six));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Seven));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Eight));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Nine));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Ten, 10));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Jack, 11));     // Gold digger.
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.Queen, 2));
            Standard.Cards.Push(new Card(Suits.Diamonds, Ranks.King, 3));

            // Clubs.
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Ace, 5));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Two));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Three));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Four));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Five));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Six));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Seven));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Eight));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Nine));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Ten, 10));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Jack, 11));     // Gold digger.
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.Queen, 2));
            Standard.Cards.Push(new Card(Suits.Clubs, Ranks.King, 3));
        }
    }
}