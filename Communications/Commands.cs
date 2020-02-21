using System;
using System.Collections.Generic;
using System.Text;

namespace GoldDigger.Communications
{
    public enum HostCommands : byte
    {
        None = 0x00,
        Information = 0x01,
        Rejected = 0x02,
        Start = 0x03,
        Terminate = 0x04
    }

    public enum GuestCommands : byte
    {
        None = 0x00,
        Information = 0x01,
        Leaving = 0x02
    }
}
