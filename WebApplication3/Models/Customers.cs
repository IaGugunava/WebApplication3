using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
