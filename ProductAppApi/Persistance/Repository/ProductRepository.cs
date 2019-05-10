using Microsoft.EntityFrameworkCore;
using ProductAppApi.Core.Domain;
using ProductAppApi.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Persistance.Repository
{
    /// <summary>
    /// this is the product repository implementing both repository the behavior of product 
    /// so the general methods are included and the iproduct interface so that any spacific behavior is also included
    /// </summary>
    public class ProductRepository : Repository<Product>, IProduct
    {
        /// <summary>
        /// here's were we pass the injected dbcontext to the repository
        /// so that it can do the work and manipulate data
        /// </summary>
        /// <param name="dbContext"></param>
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
