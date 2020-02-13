using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using PropertyChanged;
using GoldDiggerAndroid.Misc;

namespace GoldDiggerAndroid.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGame : vmBase
    {
        public string Name { get; set; } = Xamarin.Essentials.DeviceInfo.Name;
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        public RelayCommand Join { get; private set; } = new RelayCommand();

        public vmJoinGame()
        {
            Join.Callback += Join_Callback; ;
        }

        private void Join_Callback(object parameter = null)
        {
        }
    }
}
