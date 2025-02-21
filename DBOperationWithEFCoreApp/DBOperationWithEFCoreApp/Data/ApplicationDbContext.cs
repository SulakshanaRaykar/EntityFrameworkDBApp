using DBOperationWithEFCoreApp.Data.Model;
using Microsoft.EntityFrameworkCore;
using DBOperationWithEFCoreApp.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DBOperationWithEFCoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for each of your entity (domain) models
        public DbSet<Book> Book { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        // Configure domain models using ModelBuilder here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasKey(u => u.Id);
            modelBuilder.Entity<Product>().HasKey(u => u.ProductID);
            modelBuilder.Entity<Order>().HasKey(u => u.OrderID);
            modelBuilder.Entity<Sale>().HasKey(u => u.ProductName);
            modelBuilder.Entity<Purchase>().HasKey(u => u.CustomerId);
           

        }
    }
   
}