using OrderAPI.Interface;

namespace OrderAPI.Clients
{
    public class FLLuxuryTaxCalculator :  ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.0725m;
        }

    }
}
