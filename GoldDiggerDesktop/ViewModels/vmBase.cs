using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GoldDiggerDesktop.ViewModels
{
    abstract class vmBase
    {
        public Action<UserControl> ShowContent;
    }
}
