using System;
using System.Collections.Generic;
using System.Text;

using PropertyChanged;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmNewGame
    {
        public RelayCommand Host { get; private set; } = new RelayCommand();
        public RelayCommand Join { get; private set; } = new RelayCommand();
        public RelayCommand Exit { get; private set; } = new RelayCommand();

        public vmNewGame()
        {
            Host.Enable = _ => true;
            Join.Enable = _ => true;
            Exit.Enable = _ => true;
        }
    }
}
