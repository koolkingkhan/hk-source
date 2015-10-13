using System.ComponentModel;

namespace sre.model
{
    public enum AssetClass
    {
        [Description("Unknown")]
        Default = 0,

        [Description("Unknown")]
        Unknown,

        [Description("Europe")]
        Europe,

        [Description("Americas")]
        Americas,

        [Description("BOND")]
        Bond,

        [Description("GOVT")]
        Govt,

        [Description("Asia")]
        Asia,

        [Description("GOVT2")]
        Govt2,

        [Description("CONVRT")]
        Convrt,

        [Description("AGENCY")]
        Agency,

        [Description("CORP")]
        Corp,

        [Description("EMERGE")]
        Emerge,

        [Description("JUMBPF")]
        Jumbpf,

        [Description("SUPRA")]
        Supra
    }
}
