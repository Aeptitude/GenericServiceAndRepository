using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;
using Models.Interfaces;

namespace Domain.Interfaces
{
    public interface IService<T> where T : class, IEntity
    {
        Maybe<T> GetById(int id);
        IEnumerable<Maybe<T>> GetAll(Expression<Func<T, bool>> condition = null);
        void Update(T model);
        void Delete(int id);
        Maybe<T> Create(T model);
    }
}
