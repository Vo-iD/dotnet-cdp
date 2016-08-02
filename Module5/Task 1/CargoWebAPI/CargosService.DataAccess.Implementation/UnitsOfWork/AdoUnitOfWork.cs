using System;
using System.Collections;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;
using CargosService.DataAccess.Implementation.Repositories.AdoRepositories;

namespace CargosService.DataAccess.Implementation.UnitsOfWork
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private readonly AdoContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public AdoUnitOfWork()
        {
            _repositories = new Hashtable();
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
