using System;
using System.Data.Entity;
using System.Linq;
using CargosService.DataAccess.Contract.Exceptions;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;
using EntityRoot = CargosService.DataAccess.Contract.Models.EntityRoot;

namespace CargosService.DataAccess.Implementation.Repositories.EntityFrameworkRepositories
{
    public class GenericRepository<TEntity> : IFullRepository<TEntity>
        where TEntity : EntityRoot
    {
        private readonly DbFirstContext _context;
        private IDbSet<TEntity> _entities;

        public GenericRepository(DbFirstContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return _entities;
        }

        public TEntity Get(Guid id)
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

        public void Delete(Guid id)
        {
            var entity = _entities.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            Delete(entity);
        }

        private void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Remove(entity);
        }
    }
}
