using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework.Context
{
    public class ShopContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ShopDb;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => new { c.ProductId, c.CategoryId });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }


    }
}
