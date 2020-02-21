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

            var data = Player.ID.ToByteArray();
            Stream.Write(data, 0, data.Length);

            data = Constants.Encoding.GetBytes(Player.Name);
            Stream.Write(data, 0, data.Length);
        }

        void ReceiveHostInformation()
        {
            try
            {
                var data = new byte[16];
                var num = Stream.Read(data, 0, data.Length);
                var idData = data.Take(num).ToArray();
                Host.ID = new Guid(idData);

                data = new byte[1024];
                num = Stream.Read(data, 0, data.Length);
                var nameData = data.Take(num).ToArray();
                Host.Name = Constants.Encoding.GetString(nameData);
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
    }
}
