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
                GUI.HostInformation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void Rejected()
        {
            GUI.RejectedByHost();
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
            GUI.HostLeaving();
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

            GUI.OpponentsUpdate(opponents);
        }

        void FullGame()
        {
            GUI.FullGame();
            Disconnect();
        }

        void Start()
        {
            GUI.StartGame();
        }
    }
}
