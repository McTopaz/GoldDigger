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
        public RelayCommand<Opponent> Remove { get; private set; } = new RelayCommand<Opponent>();
        public Action Rejected;

        public Opponent()
        {
            Remove.Callback += Remove_Callback;
        }

        private void Remove_Callback(Opponent parameter)
        {
            Rejected();
        }
    }
}
