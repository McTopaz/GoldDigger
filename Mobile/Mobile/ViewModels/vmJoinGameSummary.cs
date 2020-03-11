using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using GoldDigger.Common;
using GoldDigger.Communications;
using PropertyChanged;

namespace GoldDigger.Mobile.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGameSummary : vmBase
    {
        public ObservableCollection<PlayerInformation> Opponents { get; private set; } = new ObservableCollection<PlayerInformation>();
        public PlayerInformation Player { get; set; }
        public PlayerInformation Host { get; set; }

        Guest Guest { get; set; }

        public vmJoinGameSummary()
        {
        }

        public void SetupCommunication()
        {
            Guest = new Guest(Player);
            Guest.GUI.HostInformation = HostInformation;
            Guest.GUI.RejectedByHost = Rejected;
            Guest.GUI.HostLeaving = HostLeaving;
            Guest.GUI.OpponentsUpdate = UpdateOpponents;
            Guest.GUI.FullGame = FullGame;
            base.BackButtonPressed = Guest.Leave;
        }

        void HostInformation()
        {
            Host = Guest.Host;
        }

        void Rejected()
        {
            var title = $"Rejected";
            var msg = $"The host choosed to exclude you from the game.";
            DisplayAlert(title, msg);
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        void HostLeaving()
        {
            var title = $"Host is leaving";
            var msg = $"The host choosed to stop the game.";
            DisplayAlert(title, msg);
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        void UpdateOpponents(IEnumerable<PlayerInformation> opponents)
        {
            Opponents = new ObservableCollection<PlayerInformation>(opponents);
        }

        void FullGame()
        {
            var title = $"Game is full";
            var msg = $"The game cannot host more players.";
            DisplayAlert(title, msg);
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
