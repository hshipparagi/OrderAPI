using OrderAPI.Interface;

namespace OrderAPI.Clients
{
    public class FLTaxCalculator :  ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.0725m;
        }

       
    }
}
