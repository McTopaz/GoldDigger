using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using PropertyChanged;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmTalon
    {
        public ObservableCollection<string> Cards { get; set; } = new ObservableCollection<string>();
    }
}
