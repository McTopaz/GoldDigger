using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    class vmJoinGame : vmSetup
    {
        public RelayCommand Join { get; private set; } = new RelayCommand();

        public vmJoinGame()
        {
            Join.Callback += Join_Callback;
        }

        private void Join_Callback(object parameter = null)
        {
            var view = new Views.JoinGameSummary();
            var vm = view.DataContext as vmJoinGameSummary;
            var endPoint = new IPEndPoint(IpAddress, Port);

            vm.Previously = this;
            vm.Player = new GuestPlayer()
            {
                EndPoint = new IPEndPoint(IpAddress, Port),
                Name = Name
            };
            vm.SetupGuest();

            ShowContent(view);
        }
    }
}
