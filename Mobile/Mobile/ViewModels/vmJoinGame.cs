using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using PropertyChanged;
using GoldDigger.Common;

namespace GoldDigger.Mobile.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGame : vmBase
    {
        public string Name { get; set; } = Xamarin.Essentials.DeviceInfo.Name;
        public IPAddress IpAddress { get; set; } = IPAddress.Broadcast;
        public int Port { get; set; } = 0xBABE;

        public RelayCommand Join { get; private set; } = new RelayCommand();

        public vmJoinGame()
        {
            Join.Callback += Join_Callback;
        }

        private void Join_Callback(object parameter = null)
        {
            var view = new Views.JoinGameSummary();
            var vm = view.BindingContext as vmJoinGameSummary;
            vm.Player = new Guest() { Name = Name, EndPoint = new IPEndPoint(IpAddress, Port) };
            ShowPage(view);
        }
    }
}
