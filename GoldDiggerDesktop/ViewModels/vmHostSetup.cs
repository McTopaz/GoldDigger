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
    class vmHostSetup : vmBase
    {
        public IEnumerable<IPAddress> NetworkCards { get; private set; }
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; } = 0xBABE;
        public string Name { get; set; } = Environment.MachineName;

        public RelayCommand Host { get; private set; } = new RelayCommand();
        public RelayCommand Back { get; private set; } = new RelayCommand();

        public vmHostSetup()
        {
            NetworkAdapters();
            DefaultIpAddress();

            Host.Callback += Host_Callback;
            Back.Callback += Back_Callback;
        }

        private void Host_Callback(object parameter = null)
        {
            var view = new Views.HostMenu();
            var vm = view.DataContext as vmHostMenu;

            vm.Previously = this;
            vm.Host = new Player()
            {
                EndPoint = new IPEndPoint(IpAddress, Port),
                Name = Name,
            };
            vm.Host.Remove.Enable = _ => false;

            ShowContent(view);
        }

        private void Back_Callback(object parameter = null)
        {
            base.ShowContent(new Views.NewGame());
        }

        void NetworkAdapters()
        {
            NetworkCards = NetworkInterface.GetAllNetworkInterfaces()
                .Select(i => i.GetIPProperties().UnicastAddresses)
                .SelectMany(u => u)
                .Where(u => u.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(i => i.Address);
        }

        void DefaultIpAddress()
        {
            using (var udp = new UdpClient())
            {
                try
                {
                    udp.Connect("8.8.8.8", 65530);
                    var ep = udp.Client.LocalEndPoint as IPEndPoint;
                    IpAddress = ep.Address;
                }
                catch
                {
                    IpAddress = IPAddress.Loopback;
                }
            }
        }
    }
}
