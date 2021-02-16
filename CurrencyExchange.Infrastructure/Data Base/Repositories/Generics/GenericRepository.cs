using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data_Base.Repositories.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity 
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
            //var str = new List<string>();
            //foreach (var entry in _context.ChangeTracker.Entries())
            //{

            //    str.Add("Name :  " + entry.Entity.GetType().Name + "State: " + entry.State.ToString());
            //}

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

           
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
