namespace OrderAPI.Models.Summary
{
    public class OrderSummary: CostSummaryBase
    {
        public OrderSummary() {
          
            
            OrderItemSummary = new List<OrderItemSummary>();
        }
        
        public  List<OrderItemSummary> OrderItemSummary {  get; set; }



    }
}
