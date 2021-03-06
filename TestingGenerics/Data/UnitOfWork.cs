﻿using System;
using System.Collections.Generic;
using TestingGenerics.Data.Interfaces;
using TestingGenerics.Models.Interfaces;

namespace TestingGenerics.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;

        private Dictionary<string, object> _repositories;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public Repository<T> Repository<T>() where T : class, IEntity
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
                return (Repository<T>) _repositories[type];

            _repositories.Add(type, Activator.CreateInstance(typeof(Repository<>).MakeGenericType(typeof(T)), _context));

            return (Repository<T>)_repositories[type];
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
