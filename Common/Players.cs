using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using PropertyChanged;

namespace GoldDigger.Common
{
    [AddINotifyPropertyChangedInterface]
    public class PlayerInformation
    {
        public Guid ID { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public string Name { get; set; }

        public PlayerInformation()
        {
            ID = Guid.NewGuid();
        }
    }

    public class Opponent : PlayerInformation
    {
        public RelayCommand Remove { get; private set; } = new RelayCommand();
        public RelayCommand<PlayerInformation> Rem { get; private set; } = new RelayCommand<PlayerInformation>();
    }
}
