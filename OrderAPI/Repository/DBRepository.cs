using OrderAPI.Interface;
using OrderAPI.Models.Summary;

namespace OrderAPI.Repository
{
    public class DBRepository : IDBRepository
    {
        ILogger<DBRepository> _loger;
        public DBRepository(ILogger <DBRepository> loger) {
            _loger = loger;
            }

        public OrderSummary ADD(OrderSummary orderSummary)
        {
            return orderSummary;
        }

        public OrderSummary GetOrder(long id)
        {
            return new OrderSummary();
        }
        public void SaveChanges()
        {
           
        }
    }
}
