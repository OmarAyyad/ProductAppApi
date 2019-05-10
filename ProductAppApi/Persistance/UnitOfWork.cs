using ProductAppApi.Core;
using ProductAppApi.Core.IRepository;
using ProductAppApi.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Persistance
{
     public class UnitOfWork : IUnitOfWork
    {
        protected readonly ProductContext _dbContext;

        public UnitOfWork(ProductContext dbContext)
        {
            _dbContext = dbContext;

            Products = new ProductRepository(_dbContext);
            

        }



        public IProduct Products { get; }



        public int complete()
        {
           return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
           _dbContext.Dispose();
        }
    }
}
