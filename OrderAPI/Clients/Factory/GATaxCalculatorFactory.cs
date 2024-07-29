using OrderAPI.Interface;
using OrderAPI.Models;

namespace OrderAPI.Clients.Factory
{
    public class GATaxCalculatorFactory: ITaxRuleFactory
    {
        public ITaxCalculator CreateTaxRule(ProductCategory category)
        {
            return category switch
            {
                ProductCategory.Regular => new GATaxCalculator(),
                ProductCategory.LuxuryItem => new GALuxuryTaxCalculator(),
                _ => throw new ArgumentException("Invalid item type Calcluator Not available", nameof(category)),
            };
        }
    }
}
