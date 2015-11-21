using System;

namespace Hussain.Infra.Model
{
   public interface IBlotterData
    {
        double TickerAvgPrice { get; set; }
        double TickerPrice { get; set; }
        double TickerPreviousPrice { get; set; }
        string TickerCode { get; set; }
        double Id { get; set; }
    }
}
