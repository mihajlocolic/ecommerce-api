using Microsoft.EntityFrameworkCore;
using System;

namespace ecommerce_api.Models
{
    public class ECommerceDbContext : DbContext
    {
        //public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }

        public string DbPath { get; }


        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Ecommerce.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");


    }
}
