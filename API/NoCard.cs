using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger.Api
{
    class NoCard : Card
    {
        public NoCard() : base (Suits.Spades, Ranks.Ace)
        {
        }

        public override string ToString() => "No card";
    }
}
