using System;
using Prism.Mvvm;

namespace Hussain.Infra.Model
{
    public class BlotterDataLatestPrices :BindableBase, Hussain.Infra.Model.IBlotterDataLatestPrices 
    {
        private double _price;

        public double TickerPrice
        {
            get { return _price; }
            set { 
            SetProperty(ref _price, value);
            }
        }

        private double _previousPrice;

        public double TickerPreviousPrice
        {
            get { return _previousPrice; }
            set { SetProperty(ref _previousPrice , value); }
        }
        

        private string _tickerCode;

        public string TickerCode
        {
            get { return _tickerCode; }
            set { SetProperty(ref _tickerCode, value); }
        }

        private DateTime _timeStamp;

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { SetProperty(ref _timeStamp,value); }
        }
        

        public override bool Equals(Object obj)
        {
            
            var rec = obj as BlotterData;
            if (rec == null)
            {
                return false;
            }
            var s2= rec.TickerCode;
            if (s2 == null)
            {
                return false;
            }
            else
                return TickerCode == s2;
        }


        public override int GetHashCode()
        {
            return TickerCode.GetHashCode();

        }

      

       
    }
}
