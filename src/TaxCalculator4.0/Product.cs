using System;

namespace hk.TaxCalculator
{
    public class Product 
    { 
        public int Id { get; set; } 
        
        public String Name { get; set; } 
        
        public decimal RawPrice { get; set; } 
        
        public decimal GetPriceWithTax(ITaxCalculator calculator) 
        { 
            return calculator.GetTax(RawPrice) + RawPrice; 
        } 
    }
}
