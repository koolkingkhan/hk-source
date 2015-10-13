using System.ComponentModel;

namespace sre.model
{
    public enum OrderState
    {
        [Description("UNKNOWN")]
        Default,

        [Description("UNKNOWN")]
        Unknown,

        [Description("SOFT")]
        Soft,

        [Description("FIRM")]
        Firm,

        [Description("ENQUIRY")]
        Enquiry,

        [Description("TRADE")]
        Trade,

        [Description("CANCELLED")]
        Cancelled,

        [Description("EXPIRED")]
        Expired,

        [Description("AVAILABILITY")]
        Availability,

        [Description("ACCEPTANCE")]
        Acceptance,

        [Description("CONFIRMATION")]
        Confirmation,

        [Description("TICKET")]
        Ticket,

        [Description("UNACCEPTABLE")]
        Unacceptable,

        [Description("START_BATCH")]
        StartBatch,

        [Description("END_BATCH")]
        EndBatch,

        [Description("AUTOBORROW_REQUEST")]
        AutoborrowRequest,

        [Description("AUTOBORROW_REQUEST_CONFIRM")]
        AutoborrowRequestConfirm        
    }
}
