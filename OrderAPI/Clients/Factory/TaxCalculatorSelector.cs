using OrderAPI.Interface;

namespace OrderAPI.Clients.Factory
{
    public class TaxCalculatorSelector
    {
       
        public ITaxRuleFactory GetTaxRuleFactory(string state)
        {
            return state.ToLower() switch
            {
                "georgia" => new GATaxCalculatorFactory(),
                "florida" => new FLTaxCalculatorFactory(),
                "new york" => new NYTaxCalculatorFactory(),
                "nevada" => new NVTaxCalculatorFactory(),
                _ => null,
            };
        }
    }
}
