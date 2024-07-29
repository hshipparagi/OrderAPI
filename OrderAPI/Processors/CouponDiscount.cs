using OrderAPI.Interface;
using OrderAPI.Models;

namespace OrderAPI.Processors
{
    public class CouponDiscount : IDiscount
    {
        private readonly decimal _discountAmount;

        public CouponDiscount(decimal discountAmount)
        {
            _discountAmount = discountAmount;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - _discountAmount;
        }
    }
}
