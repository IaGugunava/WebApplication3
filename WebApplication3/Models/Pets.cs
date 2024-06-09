using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Pets
    {
        [Key]
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public decimal Price { get; set; }
    }
}
