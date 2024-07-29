using OrderAPI.Interface;

namespace OrderAPI.Clients
{
    public class NYLuxuryTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.0425m;
        }

       
    }
}
