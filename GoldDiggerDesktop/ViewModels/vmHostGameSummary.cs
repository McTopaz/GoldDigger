using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;
using System.Threading;

using PropertyChanged;
using GoldDigger.Common;
using GoldDigger.Communications;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHostGameSummary : vmSummary
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
            var rejectCommand = new RelayCommand();

            Host = new Host(Player);
            Host.GUI.OpponentHasJoined = AddOpponent;
            Host.GUI.OpponentHasBeenRemoved = RemoveOpponent;
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

        void AddOpponent(Opponent opponent)
        {
            Opponents.Add(opponent);
            
            var command = new RelayCommand();
            var callback = Host.OpponentsRejectCallback(opponent);
        }

        void RemoveOpponent(Opponent opponent)
        {
            Opponents.Remove(opponent);
        }
    }
}
