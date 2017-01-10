using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Data.Interfaces;
using Domain.Interfaces;
using Models;
using Models.Interfaces;

namespace Domain
{
    public class GenericService<T> : IGenericService<T> where T : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGenericRepository<T> GenericRepository => _unitOfWork.Repository<T>();

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual Maybe<T> GetById(int id)
        {
            return GenericRepository.Find(x => x.Id == id);
        }

        public virtual IEnumerable<Maybe<T>> GetAll(Expression<Func<T, bool>> condition = null)
        {
            return condition != null ? GenericRepository.GetAll() : null;
        }

        public virtual Maybe<T> Find(Expression<Func<T, bool>> condition)
        {
            return GenericRepository.Find(condition);
        }

        public virtual void Update(T model)
        {
            GenericRepository.Update(model);
        }

        public virtual void Delete(int id)
        {
            GenericRepository.Delete(id);
        }

        public virtual Maybe<T> Create(T model)
        {
            return GenericRepository.Create(model);
        }
    }
}
