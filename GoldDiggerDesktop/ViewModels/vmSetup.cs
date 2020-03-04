using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

using GoldDigger.Common;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    abstract class vmSetup : vmBase
    {
        public IEnumerable<IPAddress> NetworkCards { get; private set; }
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; } = 0xBABE;
        public string Name { get; set; } = Environment.MachineName;

        public RelayCommand Back { get; private set; } = new RelayCommand();

        public vmSetup()
        {
            NetworkAdapters();
            DefaultIpAddress();

            Back.Callback += Back_Callback;
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
