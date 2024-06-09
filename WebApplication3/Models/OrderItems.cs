using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int PetId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public Orders Order { get; set; }
        [ForeignKey("PetId")]
        public Pets Pet { get; set; }
    }
}
