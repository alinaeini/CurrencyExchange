using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data.Repositories.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity ,new()
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(CurrencyExchangeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Generic Repository

        public virtual IQueryable<TEntity> GetEntities()
            => _dbSet.AsQueryable().Where(entiy => !entiy.IsDelete);

        public virtual  IEnumerable<TEntity> GetEntities(Expression<Func<TEntity,bool>> where=null,
                    Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderby=null,string includes="")
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }


            if (orderby != null)
            {
                query = orderby(query);
            }

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public virtual async Task<TEntity> GetEntityById(long entityId)
            => await _dbSet.SingleOrDefaultAsync(entity => entity.Id == entityId && !entity.IsDelete);

        public virtual async Task AddEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public virtual void RemoveEntity(TEntity entity)
        {
            entity.IsDelete = true;
            UpdateEntity(entity);
        }

        public virtual async Task RemoveEntity(long entityId)
        {
            TEntity entity = await GetEntityById(entityId);
            RemoveEntity(entity);
        }

        public virtual async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
        
        #region Disposable
        public void Dispose()
        {
            _context?.Dispose();
        }


        #endregion
    }
}
