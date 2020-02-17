using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldDigger.Api
{
    public class Client
    {
        public event Func<string, IEnumerable<(bool Available, Card Card)>, Card> SelectCard;
        public event Action<PlayerStatus> PlayerHasSelectedCard;
        public event Action<IEnumerable<PlayerStatus>, int> GameStatus;
        public event Action<(string Name, int Points), IEnumerable<Card>> EndOfTurn;
        public event Action<IEnumerable<PlayerStatus>> EndGame;

        public Client()
        {
            SelectCard += Client_SelectCard;
            PlayerHasSelectedCard += Client_PlayerHasSelectedCard;
            GameStatus += Client_GameStatus;
            EndOfTurn += Client_EndOfTurn;
            EndGame += Client_EndGame;
        }

        private Card Client_SelectCard(string name, IEnumerable<(bool Available, Card Card)> arg)
        {
            return new NoCard();
        }
        private void Client_PlayerHasSelectedCard(PlayerStatus obj)
        {
        }
        private void Client_GameStatus(IEnumerable<PlayerStatus> arg1, int arg2)
        {
        }
        private void Client_EndOfTurn((string Name, int Points) winner, IEnumerable<Card> arg2)
        {
        }
        private void Client_EndGame(IEnumerable<PlayerStatus> obj)
        {
        }

        internal Card NotifySelectCard(string name, IEnumerable<(bool Available, Card Card)> cards)
        {
            return SelectCard(name, cards);
        }

        internal void NotifyPlayerHasSelectedCard(PlayerStatus player)
        {
            PlayerHasSelectedCard(player);
        }

        internal void NotifyGameStatus(IEnumerable<PlayerStatus> players, int remainingCards)
        {
            GameStatus(players, remainingCards);
        }

        internal void NotifyEndOfTurn((string Name, int Points) winner, IEnumerable<Card> cards)
        {
            EndOfTurn(winner, cards);
        }

        internal void NotifyEndGame(IEnumerable<PlayerStatus> players)
        {
            EndGame(players);
        }
    }
}
