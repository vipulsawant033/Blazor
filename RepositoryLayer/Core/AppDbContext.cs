using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Core
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { 
            
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Product1",
                Price = 1000,
                Description = "Description1"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Product2",
                Price = 2000,
                Description = "Description2"
            });

            modelBuilder.Entity<Order>().HasData(new Models.Order
            {
                Id= 1,
                ProductId = 1,
                OrderBy = "Vipul"
            });

            modelBuilder.Entity<Order>().HasData(new Models.Order
            {
                Id = 2,
                ProductId = 1,
                OrderBy = "Shashi"
            });

            modelBuilder.Entity<Order>().HasData(new Models.Order
            {
                Id = 3,
                ProductId = 2,
                OrderBy = "Tejas"
            });

            modelBuilder.Entity<Order>().HasData(new Models.Order
            {
                Id = 4,
                ProductId = 2,
                OrderBy = "Deepak"
            });

        }
    }
}
