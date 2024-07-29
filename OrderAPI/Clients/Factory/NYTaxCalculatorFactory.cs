using OrderAPI.Interface;
using OrderAPI.Models;

namespace OrderAPI.Clients.Factory
{
    public class NYTaxCalculatorFactory: ITaxRuleFactory
    {
        public ITaxCalculator CreateTaxRule(ProductCategory category)
        {
            return category switch
            {
                ProductCategory.Regular => new NYTaxCalculator(),
                ProductCategory.LuxuryItem => new NYLuxuryTaxCalculator(),
                _ => throw new ArgumentException("Invalid item type Calcluator Not available", nameof(category)),
            };
        }
    }
}
