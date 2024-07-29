using OrderAPI.Interface;

namespace OrderAPI.Processors
{
    public class PromotionDiscount : IDiscount
    {
        private readonly decimal _discountPercentage;

        public PromotionDiscount(decimal discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }
        public decimal ApplyDiscount(decimal amount)
        {
            return amount - amount * _discountPercentage;
        }
    }
}
