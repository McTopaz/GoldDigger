using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace GoldDigger.Communications
{
    public partial class Host
    {
        public void Leaving()
        {
            Participants.ForEach(p => p.HostLeaving());
        }

        public void UpdateOpponents()
        {
            // For each participant, get the other participants (opponents) connected to the host.
            // Select the opponents´ information.
            Participants.ForEach(p => p.UpdateOpponents(Participants.Where(o => o != p).Select(o => o.Player)));
        }

        public void StartGame()
        {
        }
    }
}
