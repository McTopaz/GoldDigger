﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;

using GoldDigger.Common;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    class vmHostGame : vmSetup
    {
        public RelayCommand Host { get; private set; } = new RelayCommand();

        public vmHostGame()
        {
            Name = Environment.UserName;
            Port = Constants.ConnectPort;
            Host.Callback += Host_Callback;
        }

        private void Host_Callback(object parameter = null)
        {
            var view = new Views.HostGameSummary();
            var vm = view.DataContext as vmHostGameSummary;

            vm.Previously = this;
            vm.Player = new PlayerInformation()
            {
                EndPoint = new IPEndPoint(IpAddress, Port),
                Name = Name,
            };
            vm.SetupHost();

            ShowContent(view);
        }
    }
}
