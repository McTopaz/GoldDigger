using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;
using System.Net.Sockets;


using PropertyChanged;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHostMenu : vmBase
    {
        public ObservableCollection<Player> Opponents { get; private set; } = new ObservableCollection<Player>();
        public Player Host { get; set; }

        public RelayCommand Start { get; private set; } = new RelayCommand();
        public RelayCommand Back { get; private set; } = new RelayCommand();

        public vmHostMenu()
        {
            Start.Enable = _ => Opponents.Count > 1;

            Start.Callback += Start_Callback;
            Back.Callback += Back_Callback;
        }

        private void Start_Callback(object parameter = null)
        {
        }

        private void Back_Callback(object parameter = null)
        {
            var view = new Views.HostSetup();
            view.DataContext = base.Previously;
            ShowContent(view);
        }
    }
}
