using Microsoft.EntityFrameworkCore;
using System;

namespace ecommerce_api.Models
{
    public class ECommerceDbContext : DbContext
    {

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
           : base(options) { }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }


    }
}
