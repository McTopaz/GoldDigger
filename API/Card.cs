using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger.Api
{
    public class Card
    {
        public Suits Suit { get; private set; }
        public Ranks Rank { get; private set; }
        public int Points { get; private set; }

        public bool IsGoldDigger { get; private set; }
        public bool IsBigGoldDigger { get; private set; }
        public bool IsValueCard { get; private set; }

        public Card(Suits suit, Ranks rank, int points = 0)
        {
            Suit = suit;
            Rank = rank;
            Points = points;

            IsGoldDigger = Rank == Ranks.Jack;
            IsBigGoldDigger = Suit == Suits.Spades && Rank == Ranks.Jack;
            IsValueCard = Rank == Ranks.Ace || Rank == Ranks.Ten || Rank == Ranks.Jack || Rank == Ranks.Queen || Rank == Ranks.King;
        }

        public override string ToString() => $"{Suit}-{Rank}";
    }
}

/*
    Console.OutputEncoding = System.Text.Encoding.Unicode;
    Console.WriteLine('\uF0AA'); // 10 of spades
    https://en.wikipedia.org/wiki/Standard_52-card_deck#Unicode
*/
