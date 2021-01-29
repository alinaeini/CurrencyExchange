using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Data.Repositories.Generics;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data.Repositories
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
            return  _context
                .UserRoles
                .Any(x => x.UserId == userId && x.Role.Name == "Admin");
        }

        public async Task<Role> GetUserRoleByUserId(long userId)
         => await _context
                .UserRoles
                .Where(x => x.UserId == userId)
                .Select( x=>x.Role)
                .FirstOrDefaultAsync() ;
            
    }
}