using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using GoldDigger.Common;
using PropertyChanged;

namespace GoldDigger.Mobile.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmMainPage : vmBase
    {
        public RelayCommand Host { get; private set; } = new RelayCommand();
        public RelayCommand Join { get; private set; } = new RelayCommand();
        public RelayCommand Exit { get; private set; } = new RelayCommand();

        public vmMainPage()
        {
            Host.Callback += Host_Callback;
            Join.Callback += Join_Callback;
            Exit.Callback += Exit_Callback;
        }

        private void Host_Callback(object parameter = null)
        {
        }

        private void Join_Callback(object parameter = null)
        {
            var view = new Views.JoinGame();
            ShowPage(view);
        }

        private void Exit_Callback(object parameter = null)
        {
            Environment.Exit(0);
        }
    }
}
