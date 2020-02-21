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
        public ObservableCollection<PlayerInformation> Players { get; private set; } = new ObservableCollection<PlayerInformation>();
        public PlayerInformation Player { get; set; }
        public PlayerInformation Host { get; set; }

        Guest Guest { get; set; }

        public vmJoinGameSummary()
        {
        }

        public void SetupCommunication()
        {
            Guest = new Guest(Player);
            Guest.HostInformation = HostInformation;
            Guest.RejectedByHost = Rejected;
            base.BackButtonPressed = Guest.Leave;
        }

        void HostInformation()
        {
            Host = Guest.Host;
        }

        private void Rejected()
        {
            Navigation.PopModalAsync();
        }
    }
}
