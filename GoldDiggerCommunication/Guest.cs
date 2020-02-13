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
        public Guid ID { get; private set; }
        public string Name { get; private set; }

        public Action Rejected;

        public Guest(IPEndPoint endPoint, Guid id, string name)
        {
            EndPoint = endPoint;
            Client = new TcpClient();
            Client.Connect(endPoint);
            ReplyInformation(id, name);
        }

        public Guest(TcpClient client)
        {
            Client = client;
            EndPoint = client.Client.LocalEndPoint as IPEndPoint;
            InquiryInformation();
        }

        void InquiryInformation()
        {
            var id = "";
            var name = "";

            using (var requester = new RequestSocket($"tcp://{EndPoint.ToString()}"))
            {
                id = requester.ReceiveFrameString();
                name = requester.ReceiveFrameString();
            }

            ID = Guid.Parse(id);
            Name = name;
        }

        void ReplyInformation(Guid id, string name)
        {
            using (var responder = new ResponseSocket($"$tcp://{EndPoint.ToString()}"))
            {
                responder.SendFrame(id.ToString());
                responder.SendFrame(name);
            }
        }
    }

    public interface GuestAtHost
    {
        IPEndPoint EndPoint { get; }
        Guid ID { get; }
        string Name { get; }
    }
}
