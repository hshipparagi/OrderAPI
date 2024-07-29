namespace OrderAPI.Models
{
    public class Coupon : Discount
    {

        public decimal DiscountAmount { get; set; }
        public string Code { get; set; }
        public bool IsValid
        {
            get
            {    return DateTime.Now > StartDate
       && DateTime.Now < EndDate
       && DiscountAmount > 0m;
            } 
            }
    }
}
