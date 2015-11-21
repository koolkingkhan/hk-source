using System;
using Prism.Mvvm;

namespace Hussain.Infra.Model
{
    public class BlotterData :BindableBase, IBlotterData 
    {
        public struct BlotterDataStruct
        {
            public double TickerPrice;
            public string TickerCode;
            public double TickerId;

            public BlotterDataStruct(double price, double id, string code)
            {
                TickerPrice = price;
                TickerCode = code;
                TickerId = id;
            }
        }
        private double _price;

        public double TickerPrice
        {
            get { return _price; }
            set { 
            SetProperty(ref _price, value);
            }
        }

        private double _previousprice;

        public double TickerPreviousPrice
        {
            get { return _previousprice; }
            set
            {
                SetProperty(ref _previousprice, value);
            }
        }
        private double _avgPrice;

        public double TickerAvgPrice
        {
            get { return _avgPrice; }
            set { SetProperty(ref _avgPrice, value); }
        }

        private string _tickerCode;

        public string TickerCode
        {
            get { return _tickerCode; }
            set { SetProperty(ref _tickerCode, value); }
        }

        private double _id;

        public double Id
        {
            get { return _id; }
            set
            {
                _id = value;

            }
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
