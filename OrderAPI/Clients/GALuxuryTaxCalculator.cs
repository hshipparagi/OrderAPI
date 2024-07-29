using OrderAPI.Interface;

namespace OrderAPI.Clients
{
    public class GALuxuryTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.0625m;
        }

       
    }
}
