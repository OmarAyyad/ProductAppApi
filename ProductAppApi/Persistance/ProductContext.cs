using Microsoft.EntityFrameworkCore;
using ProductAppApi.Core.Domain;
using ProductAppApi.Persistance.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Persistance
{
    /// <summary>
    /// this is the productContext that inhert from Dbcontext 
    /// that allows me to add my dbsets and apply the configuration done in the entityconfiguration to the Database
    /// </summary>
    public class ProductContext : DbContext
    {
        /// <summary>
        /// here's how the dbcontext options is injected and passed to parent
        /// </summary>
        /// <param name="options"></param>
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// this is the dbset in which will have th data in from database
        /// </summary>
        public DbSet<Product> products { get; set; }

        /// <summary>
        /// this is an override of onmodelcreating function to add my configuration in
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

        }


        //private static DbContextOptions GetOptions(string connectionString)
        //{
        //    return new DbContextOptionsBuilder<ProductContext>()
        //            .UseSqlServer(connectionString)
        //            .Options;
        //    //return SqlServerDbContextOptionsExtensions
        //    //    .UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        //}
    }
}
