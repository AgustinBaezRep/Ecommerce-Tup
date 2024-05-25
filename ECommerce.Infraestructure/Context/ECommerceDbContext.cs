using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infraestructure.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
