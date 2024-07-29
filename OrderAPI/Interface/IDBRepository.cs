using OrderAPI.Models;
using OrderAPI.Models.Summary;

namespace OrderAPI.Interface
{
    public interface IDBRepository
    {
        public OrderSummary ADD(OrderSummary orderSummary);


        public OrderSummary GetOrder(long id);

        public void SaveChanges();
       


    }
}
