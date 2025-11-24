using Microsoft.EntityFrameworkCore;
using System;

namespace ecommerce_api.Models
{
    public class ECommerceDbContext : DbContext
    {
        //public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }

        //public string DbPath { get; }


        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb")));


    }
}
