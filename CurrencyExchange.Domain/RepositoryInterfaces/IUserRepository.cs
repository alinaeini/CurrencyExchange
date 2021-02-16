using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.EntityModels.Account;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        bool IsEmailExist(string email);
        bool IsUserExist(string userName);
        Task<User> UserExistByCheckEmail(string email, string password);
        Task<User> UserExistByCheckUserName(string userName, string password);
        Task<User> GetUserByUserName(string userName);

        Task<List<User>> GetActiveUsersExceptCurrentUserIdByCurrentUserId(long userId);


    }
}
