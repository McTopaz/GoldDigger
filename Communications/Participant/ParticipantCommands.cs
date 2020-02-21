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

            var data = Host.ID.ToByteArray();
            Stream.Write(data, 0, data.Length);

            data = Constants.Encoding.GetBytes(Host.Name);
            Stream.Write(data, 0, data.Length);
        }

        public void ReceiveParticipantInformation()
        {
            var data = new byte[16];
            var num = Stream.Read(data, 0, data.Length);
            var idData = data.Take(num).ToArray();
            Player.ID = new Guid(idData);

            data = new byte[1024];
            num = Stream.Read(data, 0, data.Length);
            var nameData = data.Take(num).ToArray();
            Player.Name = Constants.Encoding.GetString(nameData);
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
    }
}
