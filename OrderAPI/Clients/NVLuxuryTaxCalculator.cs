using OrderAPI.Interface;

namespace OrderAPI.Clients
{
    public class NVLuxuryTaxCalculator :  ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.1m;
        }

    }
}
