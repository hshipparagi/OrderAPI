using OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrderAPI
{
    internal static class OrderTestData
    {
      public static Order FakTestData()
        {
            var promotion = new Promotion { Id = 1, Code = "Black Friday", DiscountPercentage = 0.2m, StartDate = DateTime.Now.AddDays(-4), EndDate = DateTime.Now.AddDays(10) };
            var coupon = new Coupon { Id = 1, Code = "HANS789", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), DiscountAmount = 100 };

            return new Order
            {
                Id = 5,
                Promotion = promotion,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 1,
                        Product = new Product { Id = 1, Name = "Iphone", Price = 10000m, Category = ProductCategory.LuxuryItem },
                        Quantity = 1,

                        Coupon = coupon,
                    },
                    new OrderItem
                    {
                        Id = 2,
                        Product = new Product { Id = 2, Name = "Watch", Price = 100m },
                        Quantity = 3,

                    },
                    new OrderItem
                    {
                        Id = 3,
                        Product = new Product { Id = 3, Name = "Laptop", Price = 5000m },
                        Quantity = 1,

                    }
                },
                Client = new Client { Id = 1, Name = "nevada" }
            };
        }
    }
}
