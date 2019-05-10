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
    /// <summary>
    /// this is the implementation of IUnitOfWork and here's where the magic happens 
    /// all the work is done through here
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// member product context to get the value of injected productcontext in
        /// </summary>
        protected readonly ProductContext _dbContext;

        /// <summary>
        /// here's where the product context is injected
        /// and instantiating the product 
        /// </summary>
        /// <param name="dbContext"></param>
        public UnitOfWork(ProductContext dbContext)
        {
            _dbContext = dbContext;

            Products = new ProductRepository(_dbContext);


        }


        /// <summary>
        /// property of Iproduct so that you can access ur entity through here
        /// </summary>
        public IProduct Products { get; }


        /// <summary>
        /// complete function to be called to save changes to database after (adding , updating and deleting entities)
        /// </summary>
        /// <returns></returns>
        public int complete()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// dispose function to dispose the dbcontext when the work is done to keep a reusable space in memory
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
