using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;
using System.Net.Sockets;

using PropertyChanged;
using GoldDigger.Common;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmSummary : vmBase
    {
        public ObservableCollection<PlayerInformation> Opponents { get; protected set; } = new ObservableCollection<PlayerInformation>();
        public PlayerInformation Player { get; set; }

        public RelayCommand Back { get; private set; } = new RelayCommand();

        public vmSummary()
        {
            Back.Callback += Back_Callback;
        }

        protected virtual void Back_Callback(object parameter = null)
        {
            var view = new Views.HostGame();
            view.DataContext = base.Previously;
            ShowContent(view);
        }
    }
}
