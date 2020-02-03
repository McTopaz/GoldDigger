using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDiggerApi
{
    class NoCard : Card
    {
        public NoCard() : base (Suits.Spades, Ranks.Ace)
        {
        }

        public override string ToString()
        {
            return "No card";
        }
    }
}
