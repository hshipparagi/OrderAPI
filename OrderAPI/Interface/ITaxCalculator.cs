using OrderAPI.Models;

namespace OrderAPI.Interface
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal amount);
      

    }

}
