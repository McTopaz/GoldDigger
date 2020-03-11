using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public abstract partial class Connection
    {
        protected void SendPlayerInfo(PlayerInformation player)
        { 
            var data = player.ID.ToByteArray();
            Stream.Write(data, 0, data.Length);

            var name = player.Name;
            data = Constants.Encoding.GetBytes(name);
            Stream.Write(data, 0, data.Length);
        }

        protected void ReceivePlayerInfo( PlayerInformation player)
        {
            var data = new byte[16];
            var num = Stream.Read(data, 0, data.Length);
            var idData = data.Take(num).ToArray();
            player.ID = new Guid(idData);

            data = new byte[1024];
            num = Stream.Read(data, 0, data.Length);
            var nameData = data.Take(num).ToArray();
            player.Name = Constants.Encoding.GetString(nameData);
        }
    }
}
