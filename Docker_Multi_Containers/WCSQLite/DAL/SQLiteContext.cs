using Microsoft.EntityFrameworkCore;
using WCSQLite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCSQLite.DAL
{
    public class SQLiteContext : DbContext
    {
        /// <summary>    
        /// Gets or sets the orders.    
        /// </summary>    
        /// <value>The orders.</value>    
        public DbSet<Order> Orders { get; set; }

        /// <summary>    
        /// Initializes a new instance of the <see cref="OrderDbContext"/> class.    
        /// </summary>    
        /// <param name="options">The options.</param>    
        public SQLiteContext(DbContextOptions<SQLiteContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData
                (
                new Order { OrderId = 1, Name = "MSDN Order" },
                new Order { OrderId = 2, Name = "Docker Order" },
                new Order { OrderId = 3, Name = "EFCore Order" }
                );
        }
    }
}