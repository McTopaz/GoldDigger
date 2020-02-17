using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

using PropertyChanged;
using GoldDigger.Common;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmPlayerArea
    {
        public Brush Color { get; set; } = Brushes.CornflowerBlue;
        public string HandCardPath1 { get; set; }
        public string HandCardPath2 { get; set; }
        public string HandCardPath3 { get; set; }
        public string HandCardPath4 { get; set; }
        public string HandCardPath5 { get; set; }
        public string SelectedCardPath { get; set; }

        public RelayCommand HandCard1 { get; private set; } = new RelayCommand();
        public RelayCommand HandCard2 { get; private set; } = new RelayCommand();
        public RelayCommand HandCard3 { get; private set; } = new RelayCommand();
        public RelayCommand HandCard4 { get; private set; } = new RelayCommand();
        public RelayCommand HandCard5 { get; private set; } = new RelayCommand();

        public Brush SelectedCard1 { get; private set; } = Brushes.White;
        public Brush SelectedCard2 { get; private set; } = Brushes.White;
        public Brush SelectedCard3 { get; private set; } = Brushes.White;
        public Brush SelectedCard4 { get; private set; } = Brushes.White;
        public Brush SelectedCard5 { get; private set; } = Brushes.White;

        public string Name { get; set; } = "NameOfPlayer";
        public int Points { get; set; } = 128;
        public RelayCommand ShowStack { get; private set; } = new RelayCommand();

        public vmPlayerArea()
        {
        }
    }
}
