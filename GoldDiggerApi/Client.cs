using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDiggerApi
{
    public class Client
    {
        public event Func<IEnumerable<(bool Available, Card Card)>, Card> SelectedCard;
        public event Action<IEnumerable<PlayerStatus>> NewGameStatus;

        internal Card ChooseCard(IEnumerable<(bool Available, Card Card)> cards)
        {
            return SelectedCard(cards);
        }

        internal void UpdateGameStatus(IEnumerable<PlayerStatus> playerStatus)
        {
            NewGameStatus(playerStatus);
        }
    }
}
