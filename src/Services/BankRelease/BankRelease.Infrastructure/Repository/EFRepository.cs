using BankRelease.Domain.Interfaces.Repository;
using BankRelease.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BankRelease.Infrastructure.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BankReleaseContext _dbContext;

        public EFRepository(BankReleaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public IEnumerable<TEntity> All()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual TEntity FindById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsEnumerable();
        }
    }
}
