using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;

using PropertyChanged;

namespace GoldDiggerDesktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmVersion
    {
        public string GuiVersion { get; private set; } = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        public string ApiVersion { get; private set; } = FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(GoldDigger.Api.Game)).Location).ProductVersion;
    }
}
