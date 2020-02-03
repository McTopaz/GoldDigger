using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldDiggerApi
{
    internal class Deck
    {
        internal Stack<Card> Cards { get; set; }

        internal Deck()
        {
        }

        internal void AdjustForThreePlayers()
        {
            // Remove the clubs of two from the deck.
            var list = Cards.Where(c => (c.Suit != Suits.Clubs || c.Rank != Ranks.Two));
            Cards = new Stack<Card>(list);
        }

        internal void Shuffle()
        {
            var deck = new List<Card>(Cards);
            var length = deck.Count();
            var random = new Random();

            for (int i = length; i > 0; --i)
            {
                var r = random.Next(length-1);
                var temp = deck[i-1];
                deck[i-1] = deck[r];
                deck[r] = temp;
            }

            Cards = new Stack<Card>(deck);
        }

        internal void OneCardToEachPlayer(IEnumerable<Player> players)
        {
            if (Cards.Count() < players.Count())
            {
                return;
            }

            foreach (var player in players)
            {
                var card = Cards.Pop();
                player.Cards.Add(card);
            }
        }
    }
}
