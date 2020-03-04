using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using PropertyChanged;

namespace GoldDigger.Mobile.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmMainPage : vmBase
    {
        public ICommand Host { get; private set; }
        public ICommand Join { get; private set; }
        public ICommand Exit { get; private set; }

        public vmMainPage()
        {
            Host = new Command(Host_Callback);
            Join = new Command(Join_Callback);
            Exit = new Command(Exit_Callback);
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
