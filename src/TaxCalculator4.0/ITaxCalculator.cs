namespace hk.TaxCalculator
{
    public interface ITaxCalculator
    {
        decimal GetTax(decimal rawPrice);
    }
}