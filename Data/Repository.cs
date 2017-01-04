using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Data.Interfaces;
using Models;
using Models.Interfaces;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly Context _context;

        private IDbSet<T> Entities => _context.Set<T>();

        public Repository(Context context)
        {
            _context = context;
        }

        public IQueryable<Maybe<T>> GetAll(Expression<Func<T, bool>> condition = null)
        {
            return condition != null 
                ? Entities.Where(condition).Select(e => new Maybe<T>(e)) 
                : Entities.Select(e => new Maybe<T>(e));
        }

        public Maybe<T> Find(Expression<Func<T, bool>> condition = null)
        {
            return condition != null 
                ? new Maybe<T>(Entities.FirstOrDefault(condition)) 
                : Maybe<T>.None();
        }

        public Maybe<T> Create(T entity)
        {
            return entity != null 
                ? new Maybe<T>(Entities.Add(entity)) 
                : Maybe<T>.None();
        }

        public void Delete(int id)
        {
            Entities.Remove(Find(x => x.Id == id).GetInstance());
        }

        public Maybe<T> Update(T entity)
        {
            return entity != null 
                ? new Maybe<T>(Entities.Attach(entity)) 
                : Maybe<T>.None();
        }
    }
}
