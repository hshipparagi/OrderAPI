using OrderAPI.Models.Summary;
using OrderAPI.Models;

namespace OrderAPI.Interface
{
    public interface IOrderProcessor
    {
        OrderSummary OrderSummary(Order order);
    }
}
