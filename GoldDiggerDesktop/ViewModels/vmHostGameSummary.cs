using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;
using System.Threading;

using PropertyChanged;
using GoldDigger.Common;
using GoldDigger.Communications;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHostGameSummary : vmMenu
    {
        object lockObject = new object();
        public RelayCommand Start { get; private set; } = new RelayCommand();
        Host Host { get; set; }

        public vmHostGameSummary()
        {
            System.Windows.Data.BindingOperations.EnableCollectionSynchronization(Opponents, lockObject);
            Start.Enable = _ => Opponents.Count >= 1;
            Start.Callback += Start_Callback;
        }

        public void SetupHost()
        {
            Host = new Host(Player);
            Host.GuestHasJoined = GuestHasJoined;
            Host.RemoveGuest = GuestHastLeft;
        }

        private void Start_Callback(object parameter = null)
        {
            Host.StartGame();
        }

        protected override void Back_Callback(object parameter = null)
        {
            Host.Terminate();
            base.Back_Callback(parameter);
        }

        private void GuestHasJoined(Opponent player)
        {
            Opponents.Add(player);
        }

        private void GuestHastLeft(Opponent player)
        {
            Opponents.Remove(player);
        }
    }
}
