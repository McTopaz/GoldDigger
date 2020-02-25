﻿using System;
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
        TcpListener Listner { get; set; }
        bool Run { get; set; } = true;
        PlayerInformation HostInfo { get; set; }
        List<Participant> Participants { get; set; } = new List<Participant>();
        
        public Action<Opponent> GuestHasJoined;
        public Action<Opponent> RemoveGuest;

        public Host(PlayerInformation host)
        {
            HostInfo = host;
            new Thread(AcceptParticipant).Start();
        }

        void AcceptParticipant()
        {
            Listner = new TcpListener(HostInfo.EndPoint);
            Listner.Start(Constants.MaxConnection);

            while (Run)
            {
                var client = Listner.AcceptTcpClient(); // Crash after Listner.Stop() -> Exiting game.
                NewParticipant(client);
                UpdateOpponents();
            }
            Console.WriteLine("");
        }

        void NewParticipant(TcpClient client)
        {
            var participant = new Participant(client, HostInfo);
            Participants.Add(participant);
            GuestHasJoined(participant.Player as Opponent);
            participant.GUI.RemoveParticipant = RemoveParticipant;
        }

        void RemoveParticipant(Participant participant)
        {
            Participants.Remove(participant);
            RemoveGuest(participant.Player as Opponent);
        }

        public void Terminate()
        {
            Run = false;
            Listner.Stop();
            Leaving();
        }
    }
}
