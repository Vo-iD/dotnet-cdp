using System;
using DAL.Module.DataAccess.Contract.Infrastructure;
using DAL.Module.DataAccess.Contract.Models;

namespace DAL.Module.DataAccess.Implementation.UnitsOfWork
{
    public class ADOUnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IRepository<TData> Repository<TData>() where TData : EntityRoot
        {
            throw new NotImplementedException();
        }

        public void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
    }
}
