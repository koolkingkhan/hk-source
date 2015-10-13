using System.ComponentModel;

namespace sre.model
{
    public enum ProductType
    {
        [Description("UNKNOWN")]
        Default=0,
        
        [Description("UNKNOWN")]
        Unknown,

        [Description("EQUITY")]
        Equity,

        [Description("BOND")]
        Bond
    }
}
