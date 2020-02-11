using System;
using System.Collections.Generic;
using System.Text;

using PropertyChanged;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmNewGame : vmBase
    {
        public RelayCommand Host { get; private set; } = new RelayCommand();
        public RelayCommand Join { get; private set; } = new RelayCommand();
        public RelayCommand Exit { get; private set; } = new RelayCommand();

        public vmNewGame()
        {
            Host.Enable = _ => true;
            Join.Enable = _ => true;
            Exit.Enable = _ => true;

            Host.Callback += Host_Callback;
            Join.Callback += Join_Callback;
            Exit.Callback += Exit_Callback;
        }

        private void Host_Callback(object parameter = null)
        {
            ShowContent(new Views.HostGame());
        }

        private void Join_Callback(object parameter = null)
        {
            ShowContent(new Views.JoinGame());
        }

        private void Exit_Callback(object parameter = null)
        {
            Environment.Exit(0);
        }
    }
}
