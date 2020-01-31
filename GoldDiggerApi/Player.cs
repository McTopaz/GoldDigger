using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldDiggerApi
{
    public abstract class Player
    {
        public delegate Card Handler(IEnumerable<(bool Available, Card Card)> cards);
        public event Handler SelectCard;

        internal List<Card> Cards { get; set; } = new List<Card>();
        public List<Card> Stash { get; internal set; } = new List<Card>();
        public int Points { get; private set; } = 0;
        public TurnTaking TurnTaking { get; internal set; }
        internal Card Current { get; set; }
        internal bool IsFirstPlayer { get; set; }

        public Player(TurnTaking turnTaking)
        {
            TurnTaking = turnTaking;
        }

        internal Card LetPlayerChooseCard(IEnumerable<(bool Available, Card Card)> cards)
        {
            return SelectCard(cards);
        }

        internal void SummarizePoints()
        {
            Points = Stash.Sum(c => c.Points);
        }
    }
}
