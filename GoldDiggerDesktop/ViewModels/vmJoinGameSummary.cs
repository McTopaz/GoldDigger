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
            SetupGuest();
        }

        public void SetupGuest()
        {
            Guest = new Guest(Player.EndPoint);
            Guest.Rejected = Rejected;
            Guest.Information = TransferInformation;
        }

        private (Guid, string) TransferInformation()
        {
            return (Player.ID, Player.Name);
        }

        private void Rejected()
        {
            Back.Execute();
        }
    }
}
