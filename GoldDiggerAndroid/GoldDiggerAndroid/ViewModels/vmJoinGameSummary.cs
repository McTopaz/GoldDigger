using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using GoldDiggerAndroid.Misc;
using GoldDigger.Common;
using PropertyChanged;

namespace GoldDiggerAndroid.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGameSummary : vmBase
    {
        public ObservableCollection<Player> Opponents { get; private set; } = new ObservableCollection<Player>();
        public Guest Player { get; set; }
        public Host Host { get; set; }

        public RelayCommand Back { get; private set; } = new RelayCommand();

        public vmJoinGameSummary()
        {
            Back.Callback += Back_Callback;
        }

        private void Back_Callback(object parameter = null)
        {
            
        }
    }
}
