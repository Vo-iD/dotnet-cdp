using System;
using System.Collections;
using DAL.Module.DataAccess.Contract.Infrastructure;
using DAL.Module.DataAccess.Contract.Models;
using DAL.Module.DataAccess.Implementation.Repositories;
using EntityRoot = DAL.Module.DataAccess.Contract.Models.EntityRoot;

namespace DAL.Module.DataAccess.Implementation.UnitsOfWork
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly bohdan_simianyk_cdp2016q1Entities _context;
        private bool _disposed;
        private Hashtable _repositories;

        public EfUnitOfWork()
        {
            _repositories = new Hashtable();
            _context = new bohdan_simianyk_cdp2016q1Entities();
            _context.Configuration.AutoDetectChangesEnabled = false;
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
                _repositories.Add(type, new EfRepository<TData>(_context));;
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
