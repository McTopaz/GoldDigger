using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;
using System.Net.Sockets;

using PropertyChanged;
using GoldDigger.Common;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmMenu : vmBase
    {
        public ObservableCollection<PlayerInformation> Opponents { get; private set; } = new ObservableCollection<PlayerInformation>();
        public PlayerInformation Opponent { get; set; }
        public PlayerInformation Player { get; set; }

        public RelayCommand Back { get; private set; } = new RelayCommand();

        public vmMenu()
        {
            Back.Callback += Back_Callback;
        }

        private void Back_Callback(object parameter = null)
        {
            var view = new Views.HostGame();
            view.DataContext = base.Previously;
            ShowContent(view);
        }
    }
}
