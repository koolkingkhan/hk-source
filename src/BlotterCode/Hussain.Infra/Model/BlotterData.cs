using Prism.Mvvm;

namespace Hussain.Infra.Model
{
    public class BlotterData : BindableBase, IBlotterData
    {
        private double _avgPrice;

        private double _previousprice;
        private double _price;

        private string _tickerCode;

        public double TickerPrice
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public double TickerPreviousPrice
        {
            get { return _previousprice; }
            set { SetProperty(ref _previousprice, value); }
        }

        public double TickerAvgPrice
        {
            get { return _avgPrice; }
            set { SetProperty(ref _avgPrice, value); }
        }

        public string TickerCode
        {
            get { return _tickerCode; }
            set { SetProperty(ref _tickerCode, value); }
        }

        public double Id { get; set; }


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
    }
}