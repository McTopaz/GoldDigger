using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldDigger.Api
{
    public abstract class Player : PlayerStatus
    {
        public Client Client { get; private set; } = new Client();

        public string Name { get; private set; }
        internal List<Card> Cards { get; set; } = new List<Card>();
        public List<Card> Stash { get; internal set; } = new List<Card>();
        public int Points { get; private set; } = 0;
        public Card Current { get; internal set; } = new NoCard();
        public bool IsWinner { get; internal set; }

        public Player(string name)
        {
            Name = name;
        }

        internal void SummarizePoints()
        {
            Points = Stash.Sum(c => c.Points);
        }
    }

    public interface PlayerStatus
    {
        string Name { get; }
        Card Current { get; }
        List<Card> Stash { get; }
        int Points { get; }
        bool IsWinner { get; }
    }
}
