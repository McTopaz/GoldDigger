using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using PropertyChanged;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmOpponentBoard
    {
        public string Name { get; set; } = "Name of opponent";
        public string Selected { get; set; }
        public int Points { get; set; } = 128;
        public ObservableCollection<string> Stask { get; private set; } = new ObservableCollection<string>();
        public bool HandCard1 { get; set; } = true;
        public bool HandCard2 { get; set; } = true;
        public bool HandCard3 { get; set; } = true;
        public bool HandCard4 { get; set; } = true;
        public bool HandCard5 { get; set; } = true;
    }
}
