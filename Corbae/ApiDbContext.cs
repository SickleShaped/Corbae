using Corbae.Configure;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;

namespace Corbae
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderProduct> OrdersProducts { get; set; } = null!;
        public DbSet<CartProduct> CartProducts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ConfigureUser());
            builder.ApplyConfiguration(new ConfigureCart());
            builder.ApplyConfiguration(new ConfigureOrder());
            builder.ApplyConfiguration(new ConfigureProduct());
        }
    }
}