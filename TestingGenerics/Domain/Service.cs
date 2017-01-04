using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestingGenerics.Data.Interfaces;
using TestingGenerics.Domain.Interfaces;
using TestingGenerics.Models;
using TestingGenerics.Models.Interfaces;

namespace TestingGenerics.Domain
{
    public class Service<T> : IService<T> where T : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<T> Repository => _unitOfWork.Repository<T>();

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Maybe<T> GetById(int id)
        {
            return Repository.Find(x => x.Id == id);
        }

        public IEnumerable<Maybe<T>> GetAll(Expression<Func<T, bool>> condition = null)
        {
            return condition != null ? Repository.GetAll() : null;
        }

        public Maybe<T> Find(Expression<Func<T, bool>> condition)
        {
            return Repository.Find(condition);
        }

        public void Update(T model)
        {
            Repository.Update(model);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public Maybe<T> Create(T model)
        {
            return Repository.Create(model);
        }
    }
}
