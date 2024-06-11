using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class PetStoreContext : DbContext
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options) : base(options)
        {
        }

        public DbSet<Pets> Pets { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
