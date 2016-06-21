using System;
using System.Collections;
using DAL.Module.DataAccess.Contract.Infrastructure;
using DAL.Module.DataAccess.Contract.Models;
using DAL.Module.DataAccess.Implementation.Repositories.AdoRepositories;

namespace DAL.Module.DataAccess.Implementation.UnitsOfWork
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private readonly AdoContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public AdoUnitOfWork()
        {
            _context = new AdoContext();
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
                if (typeof (TData) == typeof (Cargo))
                {
                    _repositories.Add(type, new AdoCargoRepository(_context));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return (IRepository<TData>)_repositories[type];
        }
    }
}
