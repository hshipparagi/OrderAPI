using OrderAPI.Models.Summary;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class OrderItem:IdBase
    {
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Coupon Coupon { get; set; }
       



    }
}
