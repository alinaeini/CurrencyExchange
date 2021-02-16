using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using CurrencyExchange.Infrastructure.Data_Base.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data_Base.Repositories
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
            return await _context.Permissions
                .Where(x=> !x.IsDelete)
                .ToListAsync();
        }



        #endregion
    }
}