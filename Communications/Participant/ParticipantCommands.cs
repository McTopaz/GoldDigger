using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        }

        public void Leaving()
        {
            Terminate();
            GuestHasLeft(Player as Opponent);
        }

        public void Terminate()
        {
            SendCommand(HostCommands.Terminate);
            Disconnect();
        }

        public void HostLeaving()
        {
            SendCommand(HostCommands.Leaving);
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
