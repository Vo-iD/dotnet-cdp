using System;
using DAL.Module.DataAccess.Contract.Models;

namespace DAL.Module.DataAccess.Contract.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IRepository<TData> Repository<TData>() where TData : EntityRoot;

        void Dispose(bool disposing);
    }
}
