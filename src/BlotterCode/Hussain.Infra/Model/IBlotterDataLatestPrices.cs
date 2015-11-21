using System;

namespace Hussain.Infra.Model
{
    public interface IBlotterDataLatestPrices
    {
        string TickerCode { get; set; }
        double TickerPrice { get; set; }
        double TickerPreviousPrice { get; set; }
        DateTime TimeStamp { get; set; }
    }
}