using System;
using Prism.Mvvm;

namespace Hussain.Infra.Model
{
    public class BlotterDataLatestPrices : BindableBase, IBlotterDataLatestPrices
    {
        private double _previousPrice;
        private double _price;


        private string _tickerCode;

        private DateTime _timeStamp;

        public double TickerPrice
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public double TickerPreviousPrice
        {
            get { return _previousPrice; }
            set { SetProperty(ref _previousPrice, value); }
        }

        public string TickerCode
        {
            get { return _tickerCode; }
            set { SetProperty(ref _tickerCode, value); }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { SetProperty(ref _timeStamp, value); }
        }


        public override bool Equals(object obj)
        {
            var rec = obj as BlotterData;
            if (rec == null)
            {
                return false;
            }
            var s2 = rec.TickerCode;
            if (s2 == null)
            {
                return false;
            }
            return TickerCode == s2;
        }


        public override int GetHashCode()
        {
            return TickerCode.GetHashCode();
        }
    }
}