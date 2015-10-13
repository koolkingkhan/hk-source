using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace sre.model
{
    public enum SecurityType
    {
        [Description("UNKNOWN")]
        Default = 0,

        [Description("UNKNOWN")]
        Unknown,

        [Description("CUSIP")]
        Cusip,

        [Description("ISIN")]
        Isin,

        [Description("QUICK")]
        Quick,

        [Description("SEDOL")]
        Sedol
    }
}
