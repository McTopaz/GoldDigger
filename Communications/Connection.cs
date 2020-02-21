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
    public abstract class Connection
    {
        protected TcpClient Tcp { get; private set; }
        protected NetworkStream Stream { get; private set; }
        public PlayerInformation Player { get; protected set; }
        public PlayerInformation Host { get; protected set; }

        protected Dictionary<Enum, (Action Callback, bool Run)> Commands = new Dictionary<Enum, (Action, bool)>();
        protected Type CommandEnums { get; private set; }
        protected bool Run { get; set; } = true;

        /// <summary>
        /// Participant constructor.
        /// </summary>
        public Connection(Type commandEnums, TcpClient tcp, PlayerInformation host)
        {
            CommandEnums = commandEnums;
            Tcp = tcp;
            Stream = tcp.GetStream();
            Player = new Opponent();
            Player.EndPoint = tcp.Client.RemoteEndPoint as IPEndPoint;
            Host = host;
            new Thread(Receive).Start();
        }

        /// <summary>
        /// Guest constructor.
        /// </summary>
        public Connection(Type commandEnums, PlayerInformation player)
        {
            CommandEnums = commandEnums;
            Tcp = new TcpClient();
            Tcp.Connect(player.EndPoint);
            Stream = Tcp.GetStream();
            Player = player;
            Host = new PlayerInformation();
            Host.EndPoint = Tcp.Client.RemoteEndPoint as IPEndPoint;
            new Thread(Receive).Start();
        }

        protected void SendCommand(Enum command)
        {
            var b = Convert.ToByte(command);
            Stream.WriteByte(b);
        }

        void Receive()
        {
            try
            {
                while (Run)
                {
                    var data = new byte[1024];
                    var num = Stream.Read(data, 0, data.Length);
                    if (num == 1)
                    {
                        var code = data.ElementAt(0);
                        Run = HandleCommand(code);
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                // Swollow exception.
                Console.WriteLine(e.Message);
            }
        }

        bool HandleCommand(byte code)
        {
            // Get actual the command code.
            var command = InterpretCodeToEnum(code);

            // Run the command.
            Commands[command].Callback();

            // Signal if the receiver thread should continue.
            return Commands[command].Run;
        }

        protected virtual Enum InterpretCodeToEnum(byte code)
        {
            var name = Enum.GetName(CommandEnums, code);
            dynamic command = Enum.Parse(CommandEnums, name);
            return command;
        }

        protected void Disconnect()
        {
            Stream.Close();
            Stream.Dispose();
            Tcp.Close();
            Tcp.Dispose();
        }

        protected void NoneCallback()
        {
            // If the guest or host sends the "None" command, this method is executed.
            Thread.Sleep(100);
        }
    }
}
