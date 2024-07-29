using OrderAPI.Interface;
using OrderAPI.Models;

namespace OrderAPI.Clients.Factory
{
    public class NMTaxCalculatorFactory: ITaxRuleFactory
    {
        public ITaxCalculator CreateTaxRule(ProductCategory category)
        {
            return category switch
            {
                ProductCategory.Regular => new NMTaxCalculator(),
                ProductCategory.LuxuryItem => new NMLuxuryTaxCalculator(),
                _ => throw new ArgumentException("Invalid item type Calcluator Not available", nameof(category)),
            };
        }
    }
}
