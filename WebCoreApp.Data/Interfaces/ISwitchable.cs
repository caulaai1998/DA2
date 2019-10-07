using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Enums;

namespace WebCoreApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
