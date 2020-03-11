using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using GoldDigger.Common;

namespace GoldDigger.Communications
{
    public class GuestGUI
    {
        /// <summary>
        /// Update the guest's information about the host.
        /// </summary>
        public Action HostInformation;
        /// <summary>
        /// The guest was rejected by the host.
        /// </summary>
        public Action RejectedByHost;
        /// <summary>
        /// The host is leaving the game.
        /// </summary>
        public Action HostLeaving;
        /// <summary>
        /// Update with the opponents.
        /// </summary>
        public Action<IEnumerable<PlayerInformation>> OpponentsUpdate;
        /// <summary>
        /// The game is full and the guest cannot join.
        /// </summary>
        public Action FullGame;
        public Action StartGame;
    }
}
