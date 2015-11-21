namespace hk.TaxCalculator
{
    public class TaxCalculator : ITaxCalculator
    {
        public decimal GetTax(decimal rawPrice)
        {
            return 0.2M *rawPrice;
        }
    }
}