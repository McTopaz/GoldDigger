﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public partial class Participant : Connection
    {
        public Action<Opponent> GuestHasLeft;

        public Participant(TcpClient tcp, PlayerInformation host) : base (typeof(GuestCommands), tcp, host)
        {
            SetupOpponentConnections();
            Commands.Add(GuestCommands.None, (NoneCallback, true));
            Commands.Add(GuestCommands.Information, (ReceiveParticipantInformation, true));
            Commands.Add(GuestCommands.Leaving, (Leaving, false));
            Thread.Sleep(500);
            SendHostInformation();
        }

        private void SetupOpponentConnections()
        {
            var opponent = Player as Opponent;
            opponent.Rejected = Rejected;
        }
    }
}
