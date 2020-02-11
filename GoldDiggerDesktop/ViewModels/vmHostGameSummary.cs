using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;
using System.Net.Sockets;


using PropertyChanged;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHostGameSummary : vmMenu
    {
        public RelayCommand Start { get; private set; } = new RelayCommand();

        public vmHostGameSummary()
        {
            Start.Enable = _ => Opponents.Count > 1;
            Start.Callback += Start_Callback;
        }

        private void Start_Callback(object parameter = null)
        {
        }
    }
}
