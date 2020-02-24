using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public partial class Host
    {
        PlayerInformation HostInfo { get; set; }
        List<Participant> Participants { get; set; } = new List<Participant>();
        
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
                UpdateOpponents();
            }
        }

        void NewParticipant(TcpClient client)
        {
            var participant = new Participant(client, HostInfo);
            Participants.Add(participant);
            GuestHasJoined(participant.Player as Opponent);
            participant.GuestHasLeft = GuestHasLeft;
        }


    }
}
