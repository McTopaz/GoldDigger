using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public partial class Participant : Connection
    {
        public void SendHostInformation()
        {
            SendCommand(HostCommands.Information);
            SendPlayerInfo(Host);
        }

        public void ReceiveParticipantInformation()
        {
            ReceivePlayerInfo(Player);
        }

        private void Rejected()
        {
            SendCommand(HostCommands.Rejected);
            Terminate();
        }

        public void Leaving()
        {
            Terminate();
        }

        public void Terminate()
        {
            SendCommand(HostCommands.Terminate);
            Disconnect();
            GUI.RemoveParticipant(this);
        }

        public void HostLeaving()
        {
            SendCommand(HostCommands.Leaving);
            Run = false;
            Thread.Sleep(1000);
            Disconnect();
        }

        public void UpdateOpponents(IEnumerable<PlayerInformation> opponents)
        {
            SendCommand(HostCommands.Opponents);

            // Send number of opponents.
            var num = (byte)opponents.Count();
            Stream.WriteByte(num);

            // Transfer each oppponent's player information.
            foreach (var opponent in opponents)
            {
                SendPlayerInfo(opponent);
            }
        }
    }
}
