using System.ComponentModel;

namespace sre.model
{
    public enum OriginatingSystem
    {
        [Description("UNKNOWN")]
        Default = 0,

        [Description("UNKNOWN")]
        Unknown,

        [Description("EQUILEND")]
        Equilend,

        [Description("BLOOMBERG_MAIL_PARSER")]
        BloombergMailParser,

        [Description("BLOOMBERG_RFQ")]
        BloombergRfq,

        [Description("MARKETVIEW")]
        Marketview,

        [Description("MAELSTROM")]
        Maelstrom,

        [Description("UBS-MAELSTROM")]
        UbsMaelstrom,

        [Description("UBSW_MAELSTROM")]
        UbswMaelstrom
    }
}
