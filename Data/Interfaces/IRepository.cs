using System;
using System.Linq;
using System.Linq.Expressions;
using Models;
using Models.Interfaces;

namespace Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<Maybe<T>> GetAll(Expression<Func<T, bool>> condition = null);
        Maybe<T> Find(Expression<Func<T, bool>> condition = null);
        Maybe<T> Create(T entity);
        void Delete(int id);
        Maybe<T> Update(T entity);
    }
}
