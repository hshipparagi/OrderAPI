using OrderAPI.Models;

namespace OrderAPI.Interface
{
    public interface ITaxRuleFactory
    {
        ITaxCalculator CreateTaxRule(ProductCategory category);
    }
}
