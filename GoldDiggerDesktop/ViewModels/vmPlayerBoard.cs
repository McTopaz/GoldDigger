using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using PropertyChanged;
using GoldDiggerDesktop.Misc;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmPlayerBoard
    {
        public string Name { get; set; } = "Name of player";
        public string Selected { get; set; }
        public int Points { get; set; } = 128;
        public ObservableCollection<string> Stash { get; private set; } = new ObservableCollection<string>();
        public (bool Visible, string FilePath, RelayCommand Clicked) HandCard1 { get; set; } = (true, "", new RelayCommand());
        public (bool Visible, string FilePath, RelayCommand Clicked) HandCard2 { get; set; } = (true, "", new RelayCommand());
        public (bool Visible, string FilePath, RelayCommand Clicked) HandCard3 { get; set; } = (true, "", new RelayCommand());
        public (bool Visible, string FilePath, RelayCommand Clicked) HandCard4 { get; set; } = (true, "", new RelayCommand());
        public (bool Visible, string FilePath, RelayCommand Clicked) HandCard5 { get; set; } = (true, "", new RelayCommand());

        public vmPlayerBoard()
        {
            HandCard1.Clicked.Callback += Card1Clicked;
            HandCard2.Clicked.Callback += Card2Clicked;
            HandCard3.Clicked.Callback += Card3Clicked;
            HandCard4.Clicked.Callback += Card4Clicked;
            HandCard5.Clicked.Callback += Card5Clicked;
        }

        private void Card1Clicked(object parameter = null)
        {
        }

        private void Card2Clicked(object parameter = null)
        {
        }

        private void Card3Clicked(object parameter = null)
        {
        }

        private void Card4Clicked(object parameter = null)
        {
        }

        private void Card5Clicked(object parameter = null)
        {
        }
    }
}
