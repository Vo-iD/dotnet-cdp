using System;
using System.Collections;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;
using CargosService.DataAccess.Implementation.Repositories.EntityFrameworkRepositories;
using EntityRoot = CargosService.DataAccess.Contract.Models.EntityRoot;

namespace CargosService.DataAccess.Implementation.UnitsOfWork
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbFirstContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public EfUnitOfWork()
        {
            _repositories = new Hashtable();
            _context = new DbFirstContext();
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
                _repositories.Add(type, new GenericRepository<TData>(_context));;
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
