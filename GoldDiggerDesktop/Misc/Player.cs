using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Media;

namespace GoldDiggerDesktop.Misc
{
    class Player
    {
        public IPEndPoint EndPoint { get; set; }

        public string Name { get; set; }

        public RelayCommand Remove { get; private set; } = new RelayCommand();
    }
}
