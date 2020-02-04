using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldDiggerApi
{
    public class Game
    {
        const int MaxCardsOnHand = 5;
        Deck Deck { get; set; } = Decks.Standard;
        public List<Card> Trash { get; private set; } = new List<Card>();
        public IEnumerable<Player> Players { get; private set; }
        public Player Winner { get; private set; } = new NoPlayer();

        public Game(params Player[] players)
        {
            Players = players;
            Setup();
        }

        void Setup()
        {
            RandomTurnTaking();
            NumberOfPlayerControl();
            Deck.Shuffle();
            HandOutInitialCards();
        }

        void RandomTurnTaking()
        {
            var random = new Random();
            int index = random.Next(Players.Count());
            var first = Players.ElementAt(index);
            FirstAtNextTurn(first);
        }

        void NumberOfPlayerControl()
        {
            var num = Players.Count();
            if (num > 4)
            {
                throw new ArgumentException("Gold digger only support 2-4 players");
            }
            else if (num == 3)
            {
                Deck.AdjustForThreePlayers();
            }
            else if (num < 2)
            {
                throw new Exception("Gold digger requires atleasty 2 players");
            }
        }

        void HandOutInitialCards()
        {
            for (int i = 0; i < MaxCardsOnHand; i++)
            { 
                Deck.OneCardToEachPlayer(Players);
            }
        }

        public void Play()
        {
            while(Deck.Cards.Count() > 0)
            {
                GameStatus();
                var turn = new Turn(Players);
                turn.Play();

                UpdatePoints();
                Deck.OneCardToEachPlayer(Players);
                FirstAtNextTurn(turn.Winner);
            }

            CalculateWinner();
            EndGame();
        }

        void GameStatus()
        {
            foreach (var player in Players)
            {
                player.Client.NotifyGameStatus(Players, Deck.Cards.Count());
            }
        }

        void UpdatePoints()
        {
            foreach (var player in Players)
            {
                player.SummarizePoints();
            }
        }

        void FirstAtNextTurn(Player first)
        {
            var list = new List<Player>();
            list.Add(first);
            list.AddRange(Players.Where(p => p != first));
            Players = list;
        }

        void CalculateWinner()
        {
            Winner = Players.Aggregate((p1, p2) => p1.Points > p2.Points ? p1 : p2);
            Winner.IsWinner = true;
        }

        void EndGame()
        {
            foreach (var player in Players)
            {
                player.Client.NotifyEndGame(Players);
            }
        }
    }
}
