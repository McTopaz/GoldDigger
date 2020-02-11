using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    class vmHostGame : vmSetup
    {
        public RelayCommand Host { get; private set; } = new RelayCommand();

        public vmHostGame()
        {
            Host.Callback += Host_Callback;
        }

        private void Host_Callback(object parameter = null)
        {
            var view = new Views.HostGameSummary();
            var vm = view.DataContext as vmHostGameSummary;

            vm.Previously = this;
            vm.Host = new Player()
            {
                EndPoint = new IPEndPoint(IpAddress, Port),
                Name = Name,
            };
            vm.Host.Remove.Enable = _ => false;

            ShowContent(view);
        }
    }
}
