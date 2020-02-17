using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using NetMQ;
using NetMQ.Sockets;

namespace GoldDigger.Communications
{
    public class HostCommunication
    {
        const int MaxConnection = 3;    // In Gold Digger, there can only be 4 players. 3 guests and 1 host.

        IPEndPoint EndPoint { get; set; }
        public List<GuestCommunication> Guests { get; private set; } = new List<GuestCommunication>();
        public Action<OpponentAtHost> GuestHasJoined;

        public HostCommunication(IPEndPoint endPoint)
        {
            EndPoint = endPoint;
            new Thread(Run).Start();
        }

        public void Run()
        {
            AcceptGuests();
        }

        void AcceptGuests()
        {
            var listner = new TcpListener(EndPoint);
            listner.Start(MaxConnection);

            for (int i = 0; i < MaxConnection; i++)
            {
                var client = listner.AcceptTcpClient();
                NewGuest(client);
            }
        }

        void NewGuest(TcpClient client)
        {
            var guest = new GuestCommunication(client);
            Guests.Add(guest);
            GuestHasJoined(guest);
        }

        public void StartGame()
        {
        }

        public void RejectGuest()
        {

        }
    }

    public interface HostAtGuest
    {
    }
}
