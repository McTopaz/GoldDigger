using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDiggerApi
{
    public enum Suits
    {
        Spades = 0,
        Hearts = 1,
        Diamonds = 2,
        Clubs = 3
    }

    public enum Ranks
    {
        Ace = 0,
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        Seven = 6,
        Eight = 7,
        Nine = 8,
        Ten = 9,
        Jack = 13,
        Queen = 11,
        King = 12
    }

    public enum TurnTaking
    {
        First = 0,
        Second = 1,
        Third = 2,
        Forth = 3
    }
}
