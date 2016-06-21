using System;
using System.Data.Entity;
using System.Linq;
using DataAccess.Contract.Exceptions;
using DataAccess.Contract.Infrastructure;
using DataAccess.Contract.Models;

namespace DataAccess.Implementation.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityRoot
    {
        private readonly bohdan_simianyk_cdp2016q1Entities _context;
        private IDbSet<TEntity> _entities;

        public Repository(bohdan_simianyk_cdp2016q1Entities context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return _entities;
        }

        public TEntity Get(int id)
        {
            var entity = _entities.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return entity;
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var entityFromDatabase = _entities.FirstOrDefault(x => x.Id == entity.Id);
            if (entityFromDatabase != null)
            {
                throw new EntityAlreadyExistException();
            }

            _entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _entities.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            Delete(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
