using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using PropertyChanged;
using GoldDigger.Common;
using GoldDigger.Communications;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGameSummary : vmSummary
    {
        public PlayerInformation Host { get; set; }

        Guest Guest { get; set; }

        public vmJoinGameSummary()
        {
        }

        public void SetupCommunications()
        {
            Guest = new Guest(Player);
            Guest.GUI.HostInformation = HostInformation;
            Guest.GUI.RejectedByHost = Rejected;
            Guest.GUI.HostLeaving = HostLeaving;
            Guest.GUI.OpponentsUpdate = UpdateOpponents;
            Guest.GUI.FullGame = FullGame;
            Guest.GUI.StartGame = StartGame;
        }

        void HostInformation()
        {
            Host = Guest.Host;
        }

        void Rejected()
        {
            var title = $"Rejected";
            var msg = $"The host choosed to exclude you from the game.";
            System.Windows.MessageBox.Show(msg, title);
            Back_Callback();
        }

        void HostLeaving()
        {
            var title = $"Host is leaving";
            var msg = $"The host choosed to stop the game.";
            System.Windows.MessageBox.Show(msg, title);
            Back_Callback();
        }

        void UpdateOpponents(IEnumerable<PlayerInformation> opponents)
        {
            Opponents = new ObservableCollection<PlayerInformation>(opponents);
        }

        void FullGame()
        {
            var title = $"Game is full";
            var msg = $"The game cannot host more players.";
            System.Windows.MessageBox.Show(msg, title);
            Back_Callback();
        }

        void StartGame()
        {
            var view = new Views.GameBoard();
            var vm = view.DataContext as vmGameBoard;

            ShowContent(view);
        }
    }
}
