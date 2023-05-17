using System;
using POS.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace POS.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options) {
            _configuration = configuration;
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<CustomerPurchasePerProduct> CustomerPurchasePerProducts { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));

    }
}

