using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Input;

using Xamarin.Forms;

using PropertyChanged;
using GoldDigger.Common;

namespace GoldDigger.Mobile.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmJoinGame : vmBase
    {
        public string Name { get; set; } = Xamarin.Essentials.DeviceInfo.Name;
        public IPAddress IpAddress { get; set; } = IPAddress.Parse("192.168.8.104");
        public int Port { get; set; } = Constants.ConnectPort;

        //public RelayCommand Join { get; private set; } = new RelayCommand();
        public ICommand Join { get; private set; }

        public vmJoinGame()
        {
            Join = new Command(Join_Callback, _ => true);
        }

        private void Join_Callback(object parameter = null)
        {
            var view = new Views.JoinGameSummary();
            var vm = view.BindingContext as vmJoinGameSummary;
            vm.Player = new PlayerInformation()
            {
                Name = Name,
                EndPoint = new IPEndPoint(IpAddress, Port)
            };
            vm.SetupCommunication();

            ShowPage(view);
        }
    }
}
