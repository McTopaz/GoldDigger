using System;
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
        public ParticipantGUI GUI { get; private set; } = new ParticipantGUI();

        public Participant(TcpClient tcp, PlayerInformation host) : base (typeof(GuestCommands), tcp, host)
        {
            Commands.Add(GuestCommands.None, (NoneCallback, true));
            Commands.Add(GuestCommands.Information, (ReceiveParticipantInformation, true));
            Commands.Add(GuestCommands.Leaving, (Leaving, false));

            Thread.Sleep(500);
            SendHostInformation();
        }
    }
}
