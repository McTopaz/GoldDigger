using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public partial class Guest : Connection
    {
        void SendGuestInformation()
        {
            SendCommand(GuestCommands.Information);
            SendPlayerInfo(Player);
        }

        void ReceiveHostInformation()
        {
            try
            {
                ReceivePlayerInfo(Host);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                HostInformation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void Rejected()
        {
            Terminate();
            RejectedByHost();
        }

        void Terminate()
        {
            Disconnect();
        }

        void Leaving()
        {
            SendCommand(GuestCommands.Leaving);
        }

        void HostLeaving()
        {
            Terminate();
            LeavingHost();
        }

        void UpdateOpponents()
        {
            var num = Stream.ReadByte();
            var opponents = new List<PlayerInformation>();

            for (int i = 0; i < num; i++)
            {
                var opponent = new PlayerInformation();
                ReceivePlayerInfo(opponent);
                opponents.Add(opponent);
            }

            OpponentsUpdate(opponents);
        }
    }
}
