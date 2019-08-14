using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RichStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Data
{
    public class RichStoreDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Categorie> Categories { get; set; }
        public RichStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Receipt>()
               .HasOne(receipt => receipt.Order)
               .WithOne()
               .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
        }
    }
}
