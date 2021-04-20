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
    public class UserRolePermissionRepository : GenericRepository<UserRolePermission>, IUserRolePermissionRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public UserRolePermissionRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region All Methods

        public async Task<List<UserRolePermission>> GetUserRolePermissionsByUserRoleId(long userRoleId)
        {
            return await _context.UserRolePermissions
                .Include(x=>x.Permission)
                .Where(x => x.UserRoleId == userRoleId && !x.IsDelete)
                .OrderBy(x=>x.PermissionId)
                .ToListAsync();
        }

        #endregion
    }
}