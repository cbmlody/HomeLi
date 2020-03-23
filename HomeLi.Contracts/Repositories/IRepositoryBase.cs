using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HomeLi.Contracts
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Finds all entites.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Finds the entities by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}