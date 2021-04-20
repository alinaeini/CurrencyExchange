using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Account;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public UserRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion


        #region User Related Methods

        public bool IsEmailExist(string email)
        {
            var isExist = _context.Users.Any(x => x.Email == email);
            return isExist;
        }

        public bool IsUserExist(string userName)
        {
            var isExist = _context.Users.Any(x => x.UserName == userName );
            return isExist;
        }

        public async Task<User> UserExistByCheckEmail(string email, string password)
        {
            return await _context.Users
                .Where(x=>x.Email == email && x.Password == password ) 
                .SingleOrDefaultAsync();
        }
        public async Task<User> UserExistByCheckUserName(string userName, string password)
        {
            return await _context.Users
                .Where(x=>x.UserName == userName && x.Password == password ) 
                .SingleOrDefaultAsync();
        }
        //public bool IsUserActive(string email, string password)
        //{
        //    var isUserActive = _context.Users.Any(x => x.Email == email && x.Password == password );
        //    return isUserActive;
        //}

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.Users.Where(x => x.UserName == userName)
                .SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetActiveUsersExceptCurrentUserIdByCurrentUserId(long userId)
        {
            //var userNotRole = await _context.Users.Where(x => 
            //        !_context.UserRoles.Select(x => x.UserId).Contains(x.Id))
            //            .ToListAsync();
            var userNotRole = await _context.Users
                        .Where(x => x.Id != userId && 
                                    x.IsActivated && !x.IsDelete)
                        .ToListAsync();
            return userNotRole;
        }

        #endregion

    }
}
