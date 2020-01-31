using System;
using System.Collections.Generic;

using GoldDiggerApi;

namespace GoldDiggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var human = new Human(TurnTaking.First);
            var computer = new Computer(TurnTaking.Second);
            var game = new Game(human, computer);
            game.Play();
        }
    }
}
