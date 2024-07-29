using OrderAPI.Interface;

namespace OrderAPI.Clients
{
    public class NVTaxCalculator :  ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.0525m;
        }

       
    }
}
