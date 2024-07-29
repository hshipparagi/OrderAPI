using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class Client: IdBase
    {
        [Required]
        public string Name { get; set; }
    }
}
