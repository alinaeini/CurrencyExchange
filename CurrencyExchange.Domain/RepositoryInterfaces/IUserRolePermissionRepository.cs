using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IUserRolePermissionRepository : IGenericRepository<UserRolePermission>
    {
        Task<List<UserRolePermission>> GetUserRolePermissionsByUserRoleId(long userRoleId);
    }
}