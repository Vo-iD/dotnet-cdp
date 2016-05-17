using System;
using DataAccess.Contract.Models;

namespace DataAccess.Contract.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IRepository<TData> Repository<TData>() where TData : EntityRoot;

        void Dispose(bool disposing);
    }
}
