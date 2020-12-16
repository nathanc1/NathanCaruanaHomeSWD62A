using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Context
{
    public class ShoppingCartDBContext : DbContext
    {
        public ShoppingCartDBContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
