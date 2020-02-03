using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldDiggerApi
{
    public abstract class Player : Hand, PlayerStatus
    {
        public Client Client { get; private set; } = new Client();

        internal List<Card> Cards { get; set; } = new List<Card>();
        public List<Card> Stash { get; internal set; } = new List<Card>();
        public int Points { get; private set; } = 0;
        public TurnTaking TurnTaking { get; internal set; }
        public Card Current { get; internal set; } = new NoCard();

        public Player(TurnTaking turnTaking)
        {
            TurnTaking = turnTaking;
        }

        internal void SummarizePoints()
        {
            Points = Stash.Sum(c => c.Points);
        }
    }

    public interface Hand
    {
        //event Func<IEnumerable<(bool Available, Card Card)>, Card> SelectCard;
        Card Current { get; }
    }

    public interface PlayerStatus
    {
        Card Current { get; }
        List<Card> Stash { get; }
        TurnTaking TurnTaking { get; }
        int Points { get; }
    }
}
