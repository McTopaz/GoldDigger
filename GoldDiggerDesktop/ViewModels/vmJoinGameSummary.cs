using System;
using System.Collections.Generic;
using System.Text;

using PropertyChanged;
using GoldDigger.Communications;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGameSummary : vmSummary
    {
        Guest Guest;

        public vmJoinGameSummary()
        {
        }

        public void SetupGuest()
        {
            Guest = new Guest(Player);
            Guest.GUI.RejectedByHost = Rejected;
        }

        private void Rejected()
        {
            Back.Execute();
        }
    }
}
