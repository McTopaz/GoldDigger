using System;
using System.Collections.Generic;
using System.Text;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public class HostGUI
    {
        public Action<Opponent> OpponentHasJoined;
        public Action<Opponent> OpponentHasBeenRemoved;
    }
}
