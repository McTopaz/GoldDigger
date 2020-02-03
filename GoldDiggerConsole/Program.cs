using System;
using System.Linq;
using System.Collections.Generic;

using GoldDiggerApi;

namespace GoldDiggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var human = new Human(TurnTaking.First);
            var computer1 = new Computer(TurnTaking.Second);
            var computer2 = new Computer(TurnTaking.Third);
            var game = new Game(human, computer1, computer2);

            foreach (var player in game.Players)
            {
                player.Client.SelectedCard += SelectCard;
                player.Client.NewGameStatus += GameStatus;
            }

            game.Play();
        }

        private static void GameStatus(IEnumerable<PlayerStatus> obj)
        {
            Console.Clear();
            Console.WriteLine(" === Game status ===");
            Console.WriteLine("");

            foreach (var item in obj)
            {
                Console.WriteLine($"\tTurn:\t\t{item.TurnTaking}");
                Console.WriteLine($"\tCurrent:\t{item.Current}");
                Console.WriteLine($"\tPoints:\t\t{item.Points}");
                Console.WriteLine($"\tStash:\t\t{string.Join(" ", item.Stash)}");
                Console.WriteLine("");
            }
        }

        private static Card SelectCard(IEnumerable<(bool Available, Card Card)> arg)
        {
            Console.WriteLine($"Cards in hand: ");
            foreach (var item in arg)
            {
                Console.WriteLine($"\t{item.Card}\t\t{item.Available}");
            }

            Console.Write("Select card from indices 0-4: ");
            var choice = Console.ReadLine();
            var index = int.Parse(choice);

            var card = arg.Select(c => c.Card).ElementAt(index);
            Console.WriteLine($"Selected card: {card}");
            Console.WriteLine("");
            return card;
        }
    }
}

