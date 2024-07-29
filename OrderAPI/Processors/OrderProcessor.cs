using OrderAPI.Clients.Factory;
using OrderAPI.Interface;
using OrderAPI.Models;
using OrderAPI.Models.Summary;
using OrderAPI.Repository;

namespace OrderAPI.Processors
{
    public class OrderProcessor: IOrderProcessor
    {
        private readonly IDBRepository _dbRepository;
        private readonly ILogger<OrderProcessor> logger;
        public OrderProcessor(IDBRepository dbRepository,ILogger<OrderProcessor> _logger) {

            _dbRepository = dbRepository;
            _logger=logger;

        }

        public OrderSummary OrderSummary(Order order)
        {
            
                TaxCalculatorSelector taxCalculatorSelector = new TaxCalculatorSelector();
            ITaxRuleFactory taxRuleFactory = taxCalculatorSelector.GetTaxRuleFactory(order.Client.Name) ?? throw new ArgumentNullException(nameof(order.Client.Name),"Invalid Client  Calcluator Not available");
            PromotionDiscount promotionDiscount = null;
                if (order.Promotion!=null && order.Promotion.IsValid)
                {
                    promotionDiscount = new PromotionDiscount(order.Promotion.DiscountPercentage);
                }


                OrderSummary orderSummary= new OrderSummary();
                
             
                foreach (var item in order.Items)
                {

                    OrderItemSummary eachItemCost = GenerateSummary(taxRuleFactory,item, promotionDiscount);
                    orderSummary.TaxAmount += eachItemCost.TaxAmount;
                    orderSummary.PreTaxCost += eachItemCost.PreTaxCost;
                    orderSummary.TotalCost += eachItemCost.TotalCost;
                    orderSummary.OrderItemSummary.Add(eachItemCost);

            }

            _dbRepository.ADD(orderSummary);
            _dbRepository.SaveChanges();
              return orderSummary;

           
        
        }

        public virtual OrderItemSummary GenerateSummary(ITaxRuleFactory taxRuleFactory,OrderItem item, PromotionDiscount promotionDiscount)
        {
            decimal totalPrice = item.Product.Price * item.Quantity;
            decimal  promotionDiscountedPrice = totalPrice;
            decimal afterTaxCost = 0;
            decimal taxAmount = 0;
            if (promotionDiscount !=null)
            {
                 promotionDiscountedPrice = promotionDiscount.ApplyDiscount(totalPrice);
            }
            decimal couponDiscountedPrice = promotionDiscountedPrice;
            if (item.Coupon!=null && item.Coupon.IsValid)
            {
                CouponDiscount coupn = new CouponDiscount(item.Coupon.DiscountAmount);
                couponDiscountedPrice= coupn.ApplyDiscount(couponDiscountedPrice);
            }

            if (couponDiscountedPrice>0)
            {
                ITaxCalculator taacalulator = taxRuleFactory.CreateTaxRule(item.Product.Category);
                taxAmount = taacalulator.CalculateTax(couponDiscountedPrice);
                afterTaxCost  = couponDiscountedPrice+ taxAmount;
                // no need to calculate the tax becase itme is free
            }
            else
            {
                couponDiscountedPrice = 0;
            }
            return new OrderItemSummary
            {
                PreTaxCost = couponDiscountedPrice,
                TaxAmount = taxAmount,
                TotalCost = afterTaxCost,
                Id = item.Id,

            };
        }


    }
}
