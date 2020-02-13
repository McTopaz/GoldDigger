using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Media;

namespace GoldDiggerDesktop.Misc
{
    abstract class Player
    {
        public Guid ID { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public string Name { get; set; }

        public RelayCommand Remove { get; private set; } = new RelayCommand();
        public RelayCommand<Player> Rem { get; private set; } = new RelayCommand<Player>();

        public Player()
        {
            ID = Guid.NewGuid();
        }
    }

    class HostPlayer : Player {}
    class GuestPlayer : Player {}
}
