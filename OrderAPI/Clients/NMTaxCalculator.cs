using OrderAPI.Interface;
using OrderAPI.Models;

namespace OrderAPI.Clients
{
    public class NMTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
           
            return amount * 0.0525m;
        }

      
    }
}
