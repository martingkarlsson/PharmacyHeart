using Microsoft.EntityFrameworkCore;
using PharmacyOrderApi.Models;

namespace PharmacyOrderApi.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        // I verkligheten skulle man behöva lite fler entiteter som OrderItems, Products, Customers etc
    }
}
