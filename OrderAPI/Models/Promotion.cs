namespace OrderAPI.Models
{
    public class Promotion: Discount
    {
        public decimal DiscountPercentage { get; set; }
        public string Code { get; set; }
        public bool IsValid => DateTime.Now > StartDate
      && DateTime.Now < EndDate
      && DiscountPercentage > 0m;
    }
}
