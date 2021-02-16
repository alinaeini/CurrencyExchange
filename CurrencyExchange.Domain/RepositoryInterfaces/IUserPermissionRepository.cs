using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IUserPermissionRepository:IGenericRepository<Permission>
    {
        public  Task<List<Permission>> GetUserPermissions();
    }
}