using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Input;

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
        public ICommand Remove { get; set; }

        public Opponent()
        {
        }
    }
}
