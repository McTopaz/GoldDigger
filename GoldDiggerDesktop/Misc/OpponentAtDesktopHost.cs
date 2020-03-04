using System;
using System.Collections.Generic;
using System.Text;

using GoldDigger.Common;
using PropertyChanged;

namespace GoldDiggerDesktop.Misc
{
    [AddINotifyPropertyChangedInterface] 
    public class OpponentAtDesktopHost : PlayerInformation
    {
        public RelayCommand<PlayerInformation> Remove { get; private set; }
        public Action Reject;

        public OpponentAtDesktopHost()
        {
            Remove.Callback += Remove_Callback;
        }

        ~OpponentAtDesktopHost()
        {
            Remove.Callback -= Remove_Callback;
        }

        private void Remove_Callback(PlayerInformation parameter)
        {
            Reject();
        }
    }
}
