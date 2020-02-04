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
            var player1 = new LocalPlayer("Player 1");
            var player2 = new LocalPlayer("Player 2");
            var player3 = new LocalPlayer("Player 3");
            var game = new Game(player1, player2, player3);

            player1.Client.SelectCard += SelectCard;
            player2.Client.SelectCard += SelectCard;
            player3.Client.SelectCard += SelectCard;
            player1.Client.PlayerHasSelectedCard += SelectedCard;
            player2.Client.PlayerHasSelectedCard += SelectedCard;
            player3.Client.PlayerHasSelectedCard += SelectedCard;
            player1.Client.GameStatus += GameStatus;
            player1.Client.EndOfTurn += EndOfTurn;
            player1.Client.EndGame += EndGame;

            game.Play();
        }

        private static void EndOfTurn((string Name, int Points) winner, IEnumerable<Card> cards)
        {
            Console.WriteLine(" === End of turn ===");
            Console.WriteLine("");
            Console.WriteLine($"Winner:\t{winner.Name}");
            Console.WriteLine($"Points:\t{winner.Points}");
            Console.WriteLine("");
            Console.WriteLine($"Cards: {string.Join(" ", cards)}");
        }

        private static void EndGame(IEnumerable<PlayerStatus> obj)
        {
            Console.WriteLine(" === Game over ===");
            Console.WriteLine("");

            foreach (var item in obj)
            {
                Console.WriteLine($"\tWinner:\t\t{item.IsWinner}");
                Console.WriteLine($"\tPoints:\t\t{item.Points}");
                Console.WriteLine($"\tStash:\t\t{string.Join(" ", item.Stash)}");
                Console.WriteLine("");
            }
        }

        private static void GameStatus(IEnumerable<PlayerStatus> players, int remainingCards)
        {
            Console.WriteLine(" === Game status ===");
            Console.WriteLine("");

            foreach (var player in players)
            {
                Console.WriteLine($"\tName:\t\t{player.Name}");
                Console.WriteLine($"\tCurrent:\t{player.Current}");
                Console.WriteLine($"\tPoints:\t\t{player.Points}");
                Console.WriteLine($"\tStash:\t\t{string.Join(" ", player.Stash)}");                
                Console.WriteLine("");
            }

            Console.WriteLine($"\tCards remaining:\t{remainingCards}");
            Console.WriteLine("");
        }

        private static void SelectedCard(PlayerStatus player)
        {
            Console.WriteLine($"{player.Name} has selected {player.Current}");
        }

        private static Card SelectCard(string name, IEnumerable<(bool Available, Card Card)> arg)
        {
            Console.WriteLine($"{name}, cards in hand: ");
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

