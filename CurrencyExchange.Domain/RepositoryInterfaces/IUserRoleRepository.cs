using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IUserRoleRepository:IGenericRepository<UserRole>
    {
        public  bool CheckAdminRoleByUserId(long userId);
         public Task<UserRole> GetUserRoleByUserId(long userId);
    }
}