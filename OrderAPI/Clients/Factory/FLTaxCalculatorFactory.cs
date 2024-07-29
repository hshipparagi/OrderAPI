using OrderAPI.Interface;
using OrderAPI.Models;

namespace OrderAPI.Clients.Factory
{
    public class FLTaxCalculatorFactory : ITaxRuleFactory
    {
        public ITaxCalculator CreateTaxRule(ProductCategory category)
        {
            return category switch
            {
                ProductCategory.Regular => new FLTaxCalculator(),
                ProductCategory.LuxuryItem => new FLLuxuryTaxCalculator(),
                _ => throw new ArgumentException("Invalid item type Calcluator Not available", nameof(category)),
            };
        }
    }
}
