namespace Ubs.Collateral.Sre.Common.Utility
{
    interface IMfcEmailService
    {
        string EmailCredentials { get; set; }
        string EmailSendSubject { get; set; }
        string EmailSmtp { get; set; }
        System.Collections.Generic.List<string> EmUsList { get; set; }
        string EmUsrs { get; set; }
    }
}
