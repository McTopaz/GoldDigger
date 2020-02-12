using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;
using System.Threading;

using PropertyChanged;
using GoldDiggerDesktop.Misc;
using GoldDiggerCommunication;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHostGameSummary : vmMenu
    {
        public RelayCommand Start { get; private set; } = new RelayCommand();
        Host Host { get; set; }

        public vmHostGameSummary()
        {
            Start.Enable = _ => Opponents.Count > 1;
            Start.Callback += Start_Callback;
        }

        public void SetupHost()
        {
            Host = new Host(Player.EndPoint);
            Host.GuestHasJoined = GuestHasJoined;

        }

        private void Start_Callback(object parameter = null)
        {
            Host.StartGame();
        }

        private void GuestHasJoined(GuestAtHost guest)
        {
            var player = new GuestPlayer()
            {
                EndPoint = guest.EndPoint,
                Name = guest.Name
            };
            Opponents.Add(player);
            player.Remove.Callback += RemovePlayer;
        }

        private void RemovePlayer(object parameter = null)
        {
            Opponents.Remove(Opponent);
            Host.RejectGuest();
        }
    }
}
