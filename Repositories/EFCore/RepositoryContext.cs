using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories.EFCore
{
public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasData(
               new Product() {ProductId = 1, ProductName = "Laptop", Price = 12_500},
               new Product() {ProductId = 2, ProductName = "Mouse", Price = 500},
               new Product() {ProductId = 3, ProductName = "Keyboard", Price = 760},
               new Product() {ProductId = 4, ProductName = "Earpods", Price = 3_799},
               new Product() {ProductId = 5, ProductName = "Phone", Price = 32_500}
            );
        }
    }
}