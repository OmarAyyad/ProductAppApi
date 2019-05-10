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
    public class ProductRepository : Repository<Product>, IProduct
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
