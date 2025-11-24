using Microsoft.EntityFrameworkCore;
using System;

namespace ecommerce_api.Models
{
    public class ECommerceDbContext : DbContext
    {
       
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }

        //public string DbPath { get; }


        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options) { }

    }
}
