using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger.Common
{
    public static class Constants
    {
        public static int MaxConnection = 3;    // In Gold Digger, there can only be 4 players. 3 guests and 1 host.
        public static Encoding Encoding { get; set; } = Encoding.UTF8;
        public static int ConnectPort = 0xBABE;
    }
}
