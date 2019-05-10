using Microsoft.EntityFrameworkCore;
using ProductAppApi.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Persistance.Repository
{
    /// <summary>
    /// this is the repository class that implement Irepository of general behavior of entities
    /// and that entity must be a class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// init a member var dbcontext to use later to manipulate data
        /// </summary>
        protected readonly DbContext dbContext;

        /// <summary>
        /// just a member dbset of the entity to make things easier 
        /// NOTE (code do all the work with dbcontext .. but this is more readable)
        /// </summary>
        protected readonly DbSet<TEntity> entities;


        /// <summary>
        /// this is the constructor to get the injected dbcontext and give it's reference to our member dbcontext
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }


        /// <summary>
        /// add methoed that takes the entity and add it to entities in the dbcontext
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        /// <summary>
        /// add range methoed that takes range of entities and add them to entities in the dbcontext
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.entities.AddRange(entities);
        }

        /// <summary>
        /// find method that takes lambda expression and search for the entity of entities and return them
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
             return entities.Where(predicate);
        }


        /// <summary>
        /// update method that take the entity and update the new values
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            entities.Attach(entity);
            dbContext.Entry(entity).State =  EntityState.Modified;

         }

        /// <summary>
        /// get method that takes id and return the entity after finding it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id)
        {
            return entities.Find(id);
        }

        /// <summary>
        /// get all method that return all entities of that same type Entity
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

        /// <summary>
        /// remove method that takes id and search for entity and remove it
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            TEntity entity = Get(id);
            entities.Remove(entity);
        }

        /// <summary>
        /// remove range method that takes the entities and remove them from dbcontext 
        /// (and of course after calling the complete method it would be removed from Database and that goes for all behaviors except the search and get ones )
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.entities.RemoveRange(entities);
        }

    }
}
