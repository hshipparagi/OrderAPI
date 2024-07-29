using OrderAPI.Interface;

namespace OrderAPI.Clients
{
    public class GATaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.0625m;
        }

       
    }
}
