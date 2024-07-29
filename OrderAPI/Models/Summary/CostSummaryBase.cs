namespace OrderAPI.Models.Summary
{
    public class CostSummaryBase:IdBase
    {
     public   CostSummaryBase()
        {
            TotalCost = 0;
            TaxAmount = 0;
            PreTaxCost = 0;
        }
        public decimal TotalCost { get; set; }
        public decimal PreTaxCost { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
