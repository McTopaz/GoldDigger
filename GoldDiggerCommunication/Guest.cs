using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using NetMQ;
using NetMQ.Sockets;

namespace GoldDiggerCommunication
{
    public class Guest : GuestAtHost
    {
        TcpClient Client { get; set; }
        public IPEndPoint EndPoint { get; private set; }
        public string Name { get; private set; }

        public Action Rejected;
        public Func<(Guid ID, string Name)> Information;

        public Guest(IPEndPoint endPoint)
        {
            EndPoint = endPoint;
            Client = new TcpClient();
            Client.Connect(endPoint);
        }

        public Guest(TcpClient client, string name)
        {
            Client = client;
            Name = name;
            EndPoint = client.Client.LocalEndPoint as IPEndPoint;
        }

        private void WaitToSendInformation()
        {
            var information = Information();
            using (var responder = new ResponseSocket($"$tcp://{EndPoint.ToString()}"))
            {
                var data = "";
                //responder.SendMultipartBytes(new byte[][] )
            }
        }
    }

    public interface GuestAtHost
    {
        IPEndPoint EndPoint { get; }
        string Name { get; }
    }
}
