using HomeLi.Contracts;
using HomeLi.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HomeLi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected LibraryContext LibraryContext { get; set; }

        protected RepositoryBase(LibraryContext libraryContext)
        {
            LibraryContext = libraryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.LibraryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.LibraryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.LibraryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.LibraryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.LibraryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.LibraryContext.SaveChanges();
        }
    }
}