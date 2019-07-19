using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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


            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var category = new[]
            {
                new Category { Id = 1, Name = "Technology"},
                new Category { Id = 2, Name = "Home"},
                new Category { Id = 3, Name = "Garden"}
            };

            var random = new Random();

            modelBuilder.Entity<Category>().HasData(category);

            var products = Enumerable.Range(1, 10)
                .Select(i => new Product
                {
                    Id = i,
                    Name = "Product " + i,
                    Price = Convert.ToInt32(random.NextDouble() * 100).ToString(),
                    CategoryId = category[i % category.Length].Id
                }).ToArray();

            modelBuilder.Entity<Product>().HasData(products);
        }

    }
}
