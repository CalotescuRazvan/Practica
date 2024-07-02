using CalotescuPractica.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CalotescuPractica.DataLayer.CSTPractica
{
    public class FoodDeliveryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Courier> Couriers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("your_connection_string");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<User>().HasMany(u => u.Addresses).WithOne(a => a.User);
        modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);
        modelBuilder.Entity<User>().HasMany(u => u.PaymentMethods).WithOne(p => p.User);
        modelBuilder.Entity<Restaurant>().HasMany(r => r.MenuItems).WithOne(m => m.Restaurant);
        modelBuilder.Entity<Restaurant>().HasMany(r => r.Reviews).WithOne(rv => rv.Restaurant);
        modelBuilder.Entity<MenuItem>().HasMany(mi => mi.Reviews).WithOne(rv => rv.MenuItem);
        modelBuilder.Entity<MenuItem>().HasOne(mi => mi.ProductCategory).WithMany(pc => pc.MenuItem);
        modelBuilder.Entity<Order>().HasMany(o => o.OrderItems).WithOne(oi => oi.Order);
        modelBuilder.Entity<Order>().HasOne(o => o.Courier).WithMany(c => c.Order);
        modelBuilder.Entity<Review>().HasOne(rv => rv.User).WithMany(u => u.Revie);
        }
    }

}
