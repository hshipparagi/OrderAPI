using Moq;
using OrderAPI.Models.Summary;
using OrderAPI.Models;
using OrderAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderAPI.Interface;
using OrderAPI.Repository;
using Microsoft.Extensions.Logging;

namespace TestOrderAPI
{
    public class OrderProcessorTests
    {
        private readonly Mock<IDBRepository> _dbRepository;
        private readonly Mock<ILogger<OrderProcessor> >_logger;
        private readonly OrderProcessor _orderProcessor;
        private readonly Order _order;
        private readonly Client _client;
        private readonly Promotion _promotion;
        private readonly Coupon _coupon;
        public OrderProcessorTests()
        {
            _dbRepository = new Mock<IDBRepository>();
            _logger = new Mock<ILogger<OrderProcessor>>();
            _orderProcessor= new OrderProcessor(_dbRepository.Object, _logger.Object);
            _order = OrderTestData.FakTestData();
            _client=_order.Client;
            _promotion=_order.Promotion;
            _coupon= new Coupon { Id = 1, Code = "HANS789", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), DiscountAmount = 1000 };


        }

        [Fact]
        public void ShouldThrowExceptionIfClientFactoryIsNull()
        {
            _client.Name = "TATA";

          Exception exception= Assert.Throws<ArgumentNullException>(() => _orderProcessor.OrderSummary(_order));

            Assert.Contains("Name", exception.Message);
        }

        [Theory]
        [InlineData("florida", 12140, 880.15, 13020.15)]
        [InlineData("georgia", 12140, 758.75, 12898.75)]
        [InlineData("new york", 12140, 515.95, 12655.95)]
        [InlineData("nevada", 12140, 1012.6, 13152.6)]
        public void ShouldReturnSummaryWithValidCoupnandPramotionOrderSummary(string clientname, decimal PreTaxCost,decimal TaxAmount, decimal  TotalCost)
        {
            _client.Name = clientname;

            OrderSummary result= _orderProcessor.OrderSummary(_order);
            Assert.NotNull(result);
            Assert.Equal(PreTaxCost, result.PreTaxCost);
            Assert.Equal(TaxAmount, result.TaxAmount);
            Assert.Equal(TotalCost, result.TotalCost);
          
        }


        [Theory]
        [InlineData("florida", 15200, 1102, 16302)]
        [InlineData("georgia", 15200, 950, 16150)]
        [InlineData("new york", 15200, 646, 15846)]
        [InlineData("nevada", 15200, 1268.25, 16468.25)]
        public void ShouldReturnSummaryWithValidCoupnandExpiredPramotionOrderSummary(string clientname, decimal PreTaxCost, decimal TaxAmount, decimal TotalCost)
        {
            _client.Name = clientname;
            _order.Promotion=_promotion;
            _order.Promotion.StartDate = DateTime.Now.AddDays(3);
            OrderSummary result = _orderProcessor.OrderSummary(_order);
            Assert.NotNull(result);
            Assert.Equal(PreTaxCost, result.PreTaxCost);
            Assert.Equal(TaxAmount, result.TaxAmount);
            Assert.Equal(TotalCost, result.TotalCost);

        }

        [Theory]
        [InlineData("florida", 15200, 1102, 16302)]
        [InlineData("georgia", 15200, 950, 16150)]
        [InlineData("new york", 15200, 646, 15846)]
        [InlineData("nevada", 15200, 1268.25, 16468.25)]
        public void ShouldReturnSummaryWithValidCoupnandExpiredEndDatePramotionOrderSummary(string clientname, decimal PreTaxCost, decimal TaxAmount, decimal TotalCost)
        {
            _client.Name = clientname;
            _order.Promotion = _promotion;
            _order.Promotion.EndDate = DateTime.Now.AddDays(-3);
            OrderSummary result = _orderProcessor.OrderSummary(_order);
            Assert.NotNull(result);
            Assert.Equal(PreTaxCost, result.PreTaxCost);
            Assert.Equal(TaxAmount, result.TaxAmount);
            Assert.Equal(TotalCost, result.TotalCost);

        }


        [Theory]
        [InlineData("florida", 12140, 880.15, 13020.15)]
        [InlineData("georgia", 12140, 758.75, 12898.75)]
        [InlineData("new york", 12140, 515.95, 12655.95)]
        [InlineData("nevada", 12140, 1012.6, 13152.6)]
        public void ShouldReturnSummaryWithExpiredCoupnandValidPramotionOrderSummary(string clientname, decimal PreTaxCost, decimal TaxAmount, decimal TotalCost)
        {
            _client.Name = clientname;
            _order.Promotion= _promotion;
            OrderSummary result = _orderProcessor.OrderSummary(_order);

            foreach (var item in _order.Items)
            {
                if (item.Coupon != null)
                {
                    item.Coupon.StartDate = DateTime.Now.AddDays(3);
                }

            }
            Assert.NotNull(result);
            Assert.Equal(PreTaxCost, result.PreTaxCost);
            Assert.Equal(TaxAmount, result.TaxAmount);
            Assert.Equal(TotalCost, result.TotalCost);

        }

        [Theory]
        [InlineData("florida", 15200, 1102, 16302)]
        [InlineData("georgia", 15200, 950, 16150)]
        [InlineData("new york", 15200, 646, 15846)]
        [InlineData("nevada", 15200, 1268.25, 16468.25)]
        public void ShouldReturnSummaryWithExpiredCoupnandExpiredPramotionOrderSummary(string clientname, decimal PreTaxCost, decimal TaxAmount, decimal TotalCost)
        {
            _client.Name = clientname;
            _order.Promotion = _promotion;
            _order.Promotion.StartDate= DateTime.Now.AddDays(3);
            OrderSummary result = _orderProcessor.OrderSummary(_order);

            foreach (var item in _order.Items)
            {
                if (item.Coupon != null)
                {
                    item.Coupon.StartDate = DateTime.Now.AddDays(3);
                }

            }
            Assert.NotNull(result);
            Assert.Equal(PreTaxCost, result.PreTaxCost);
            Assert.Equal(TaxAmount, result.TaxAmount);
            Assert.Equal(TotalCost, result.TotalCost);


        }


        [Theory]
        [InlineData("florida", 15300, 1109.25, 16409.25)]
        [InlineData("georgia", 15300, 956.25, 16256.25)]
        [InlineData("new york", 15300, 650.25, 15950.25)]
        [InlineData("nevada", 15300, 1278.25, 16578.25)]
        public void ShouldReturnSummaryWithoutCoupnandPramotionOrderSummary(string clientname, decimal PreTaxCost, decimal TaxAmount, decimal TotalCost)
        {
            _client.Name = clientname;
            _order.Promotion = null;
            foreach (var item in _order.Items)
            {
                item.Coupon = null;

            }
            OrderSummary result = _orderProcessor.OrderSummary(_order);
            Assert.NotNull(result);
            Assert.Equal(PreTaxCost, result.PreTaxCost);
            Assert.Equal(TaxAmount, result.TaxAmount);
            Assert.Equal(TotalCost, result.TotalCost);

        }


    }
}
