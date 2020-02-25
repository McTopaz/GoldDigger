using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public partial class Guest : Connection
    {
        public GuestGUI GUI { get; private set; } = new GuestGUI();

        public Guest(PlayerInformation player) : base(typeof(HostCommands), player)
        {
            Commands.Add(HostCommands.None, (NoneCallback, true));
            Commands.Add(HostCommands.Information, (ReceiveHostInformation, true));
            Commands.Add(HostCommands.Rejected, (Rejected, false));
            Commands.Add(HostCommands.Terminate, (Terminate, false));
            Commands.Add(HostCommands.Leaving, (HostLeaving, false));
            Commands.Add(HostCommands.Opponents, (UpdateOpponents, true));
            Thread.Sleep(500);
            SendGuestInformation();
        }

        public void Leave()
        {
            Leaving();
        }
    }
}
