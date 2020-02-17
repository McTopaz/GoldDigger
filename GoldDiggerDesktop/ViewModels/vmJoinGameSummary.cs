using System;
using System.Collections.Generic;
using System.Text;

using PropertyChanged;
using GoldDiggerDesktop.Misc;
using GoldDigger.Communications;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGameSummary : vmMenu
    {
        GuestCommunication Guest { get; set; }

        public vmJoinGameSummary()
        {
        }

        public void SetupGuest()
        {
            Guest = new GuestCommunication(Player.EndPoint, Player.ID, Player.Name);
            Guest.Rejected = Rejected;
        }

        private void Rejected()
        {
            Back.Execute();
        }
    }
}
