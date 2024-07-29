using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class Product:IdBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ProductCategory Category { get; set; }
    }
}
