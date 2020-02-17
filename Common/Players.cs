using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace GoldDigger.Common
{
    public abstract class Player
    {
        public Guid ID { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public string Name { get; set; }

        public Player()
        {
            ID = Guid.NewGuid();
        }
    }

    public class Host : Player
    {
    }

    public class Opponent : Player
    {
        public RelayCommand Remove { get; private set; } = new RelayCommand();
        public RelayCommand<Player> Rem { get; private set; } = new RelayCommand<Player>();
    }

    public class Guest : Player
    {
    }
}
