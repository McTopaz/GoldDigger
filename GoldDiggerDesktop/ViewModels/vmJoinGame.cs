using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

using GoldDigger.Common;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    class vmJoinGame : vmSetup
    {
        public RelayCommand Join { get; private set; } = new RelayCommand();

        public vmJoinGame()
        {
            Name = Environment.UserName;
            IpAddress = IPAddress.Parse("192.168.8.105");
            Port = Constants.ConnectPort;
            Join.Callback += Join_Callback;
        }

        private void Join_Callback(object parameter = null)
        {
            var view = new Views.JoinGameSummary();
            var vm = view.DataContext as vmJoinGameSummary;

            vm.Previously = this;
            vm.Player = new PlayerInformation()
            {
                Name = Name,
                EndPoint = new IPEndPoint(IpAddress, Port)
            };
            vm.SetupCommunications();

            ShowContent(view);
        }
    }
}
