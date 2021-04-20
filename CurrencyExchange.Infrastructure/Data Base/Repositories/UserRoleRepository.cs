using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;

        public UserRoleRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion


        #region User Related Methods



        #endregion

        public bool CheckAdminRoleByUserId(long userId)
        {
            return _context
                .UserRoles
                .Any(x => x.UserId == userId && x.Role.Name == "Admin");
        }

        public async Task<UserRole> GetUserRoleByUserId(long userId)
            => await _context
                .UserRoles
                .Include(x => x.Role)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

        public async Task<List<UserRole>> GetUserRoleListExceptCurrentUserByUserId(long userId)
            => await _context.UserRoles
                    .Where(x => x.UserId != userId)
                    .ToListAsync();

        //    public async Task<List<UserRole> GetUserRoleListExceptCurrentUserByUserId(long userId)
        //=> await _context.UserRoles
        //.Where(x => x.UserId != userId)
        //.ToListAsync();

    }

}