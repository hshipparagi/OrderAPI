using OrderAPI.Interface;
using OrderAPI.Models;

namespace OrderAPI.Clients.Factory
{
    public class NVTaxCalculatorFactory: ITaxRuleFactory
    {
        public ITaxCalculator CreateTaxRule(ProductCategory category)
        {
            return category switch
            {
                ProductCategory.Regular => new NVTaxCalculator(),
                ProductCategory.LuxuryItem => new NVLuxuryTaxCalculator(),
                _ => throw new ArgumentException("Invalid item type Calcluator Not available", nameof(category)),
            };
        }
    }
}
