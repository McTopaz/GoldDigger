using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public class Host
    {
        PlayerInformation HostInfo { get; set; }
        
        public Action<Opponent> GuestHasJoined;
        public Action<Opponent> GuestHasLeft;

        public Host(PlayerInformation host)
        {
            HostInfo = host;
            new Thread(AcceptParticipant).Start();
        }

        void AcceptParticipant()
        {
            var listner = new TcpListener(HostInfo.EndPoint);
            listner.Start(Constants.MaxConnection);

            while (true)
            {
                var client = listner.AcceptTcpClient();
                NewParticipant(client);
            }
        }

        void NewParticipant(TcpClient client)
        {
            var participant = new Participant(client, HostInfo);
            GuestHasJoined(participant.Player as Opponent);
            participant.GuestHasLeft = GuestHasLeft;
        }

        public void StartGame()
        {
        }

        public void RejectGuest()
        {
        }
    }
}
