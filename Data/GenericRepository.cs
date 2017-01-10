using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Common.Interfaces;
using Data.Interfaces;
using Models;
using Models.Interfaces;

namespace Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly Context _context;
        private readonly ILogger _logger;

        private IDbSet<T> Entities => _context.Set<T>();

        public GenericRepository(Context context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public IQueryable<Maybe<T>> GetAll(Expression<Func<T, bool>> condition = null)
        {
            var entities = new List<Maybe<T>>().AsQueryable();

            try
            {
                entities = condition != null
                    ? Entities.Where(condition).Select(e => new Maybe<T>(e))
                    : Entities.Select(e => new Maybe<T>(e));
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }

            return entities;
        }

        public Maybe<T> Find(Expression<Func<T, bool>> condition = null)
        {
            var entity = new Maybe<T>(null);

            try
            {
                entity = condition != null
                    ? new Maybe<T>(Entities.FirstOrDefault(condition))
                    : Maybe<T>.None();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }

            return entity;
        }

        public Maybe<T> Create(T entity)
        {
            var newEntity = new Maybe<T>(null);

            try
            {
                newEntity = entity != null
                    ? new Maybe<T>(Entities.Add(entity))
                    : Maybe<T>.None();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }

            return newEntity;
        }

        public void Delete(int id)
        {
            try
            {
                Entities.Remove(Find(x => x.Id == id).GetInstance());
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }
        }

        public Maybe<T> Update(T entity)
        {
            var ammendedEntity = new Maybe<T>(null);

            try
            {
                ammendedEntity = entity != null
                ? new Maybe<T>(Entities.Attach(entity))
                : Maybe<T>.None();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }

            return ammendedEntity;
        }
    }
}
