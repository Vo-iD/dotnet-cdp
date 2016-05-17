using System;
using System.Collections;
using DataAccess.Contract.Infrastructure;
using DataAccess.Contract.Models;

namespace DataAccess.Implementation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly bohdan_simianyk_cdp2016q1Entities _context;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork()
        {
            _repositories = new Hashtable();
            _context = new bohdan_simianyk_cdp2016q1Entities();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IRepository<TData> Repository<TData>() where TData : EntityRoot
        {
            var type = typeof(TData).Name;

            if (!_repositories.ContainsKey(type))
            {
                _repositories.Add(type, new Repository<TData>(_context));;
            }

            return (IRepository<TData>)_repositories[type];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                   _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
