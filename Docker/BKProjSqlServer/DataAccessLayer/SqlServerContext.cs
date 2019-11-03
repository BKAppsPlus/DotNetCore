using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BKProjSqlServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BKProjSqlServer.DataAccessLayer
{
    public class SqlServerContext : DbContext
    {
        /// <summary>  
        /// Initializes a new instance of the <see cref="SqlServerContext"/> class.  
        /// </summary>  
        /// <param name="options">The options.</param>  
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            // Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
            this.Database.EnsureCreated();
        }

        /// <summary>  
        /// Gets or sets the products.  docker container prune 
        /// 
        /// </summary>  
        /// <value>The products.</value>  
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
