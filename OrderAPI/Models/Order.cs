using OrderAPI.Models.Summary;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class Order:IdBase
    {
        public Order()
        {
            Items= new List<OrderItem>();
        }

        [Required]
        public IEnumerable<OrderItem> Items { get; set; }

        [Required]
        public Client Client { get; set; }

        public Promotion Promotion { get; set; }
       
    }
}
