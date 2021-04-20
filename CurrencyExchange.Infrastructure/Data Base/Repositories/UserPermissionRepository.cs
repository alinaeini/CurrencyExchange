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
    public class UserPermissionRepository : GenericRepository<Permission>, IUserPermissionRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;

        public UserPermissionRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region All Methods

        public async Task<List<Permission>> GetUserPermissions()
        {
            //var permissions = await _context.Permissions
            //   .Where(x => !x.IsDelete)
            //   .ToListAsync();

            var permissions = await _context.Permissions
                .Include(e => e.Parent)
                .Include(e => e.Permissions)
                .Where(e => e.ParentId == null && !e.IsDelete)
                .ToListAsync();

            //var result = await _context.Permissions.Select(g => SelectGenreName(Permission, g));

            return permissions;
        }
        #endregion
    }
}