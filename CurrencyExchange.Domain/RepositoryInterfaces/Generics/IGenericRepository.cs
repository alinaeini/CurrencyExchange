using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Common;

namespace CurrencyExchange.Domain.RepositoryInterfaces.Generics
{
    //if use class insted of base entity , you can use dtos or Dtos 
    //we  want to use just Entity 
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetEntities();

        IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "");
        Task<TEntity> GetEntityById(long entityId);
        Task AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void RemoveEntity(TEntity entity);
        Task RemoveEntity(long entityId);
        Task SaveChanges();
    }
}
