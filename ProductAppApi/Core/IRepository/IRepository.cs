using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Core.IRepository
{
    /// <summary>
    /// this is the IRepository interface to determine the guidlines that the behavior of every entity should be
    /// and the generic TEntity must be class and not any other type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// get method that takes id and returns the entity for that id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// get all method that take no parameter and return all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// find method the takes a lambda expresstion and returns the searched entity 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// add method that takes an entity to add 
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// add range method that takes IEnumerable of entities to add that range of entities
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// update method that takes an entity to update 
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// remove method that takes id and remove the entity from DataBase
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);

        /// <summary>
        /// remove range method that takes IEnumerable of entities and remove them
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
