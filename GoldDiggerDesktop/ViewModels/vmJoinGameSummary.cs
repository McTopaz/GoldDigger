using System;
using System.Collections.Generic;
using System.Text;

using PropertyChanged;
using GoldDiggerDesktop.Misc;
using GoldDiggerCommunication;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGameSummary : vmMenu
    {
        Guest Guest { get; set; }

        public vmJoinGameSummary()
        {
        }

        public void SetupGuest()
        {
            Guest = new Guest(Player.EndPoint, Player.ID, Player.Name);
            Guest.Rejected = Rejected;
        }

        private void Rejected()
        {
            Back.Execute();
        }
    }
}
