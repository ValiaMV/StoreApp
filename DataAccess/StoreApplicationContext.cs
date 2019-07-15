using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class StoreApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketProduct> BasketProducts { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Order> Orders { get; set; }

        public StoreApplicationContext(DbContextOptions<StoreApplicationContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketProduct>()
                .HasKey(bp => new { bp.BasketId, bp.ProductId });

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(prod => prod.BasketProducts)
                .HasForeignKey(bp => bp.ProductId);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Basket)
                .WithMany(basket => basket.BasketProducts)
                .HasForeignKey(bp => bp.BasketId);



            modelBuilder.Entity<Category>()
                .HasMany<Product>(cat => cat.Products)
                .WithOne(prod => prod.Category)
                .HasForeignKey(prod => prod.CategoryId);



            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(prod => prod.OrderProducts)
                .HasForeignKey(bp => bp.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(bp => bp.Order)
                .WithMany(basket => basket.OrderProducts)
                .HasForeignKey(bp => bp.OrderId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
