using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.ExchangeDeclaration;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using CurrencyExchange.Infrastructure.Data_Base.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data_Base.Repositories
{
    public class ExDeclarationRepository : GenericRepository<ExDeclaration>, IExDeclarationRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public ExDeclarationRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region ExDeclaration Related Methods

        #region IsCodeExist

        public bool IsCodeExist(string exCode)
        {
            var isExist = _context.ExDeclarations.Any(x => x.ExchangeDeclarationCode == exCode);
            return isExist;
        }

        #endregion

        #region Soled

        public async Task<bool> SoldedDeclaration(long id)
        {
            var declaration = await _context.ExDeclarations.FirstOrDefaultAsync(x => x.Id == id);
            declaration.IsSold = true;
            _context.ExDeclarations.Update(declaration);
           // await _context.SaveChangesAsync();
            return true;

        }

        #endregion

        #region GetSumBrokerAccountBalance

        public async Task<long> GetSumExDecAccountBalance()
        {
            return await _context.ExDeclarations
                .Where(entity => !entity.IsSold)
                .SumAsync(x => x.Price);
        }

        #endregion


        #region GetAccountBalanceByDetailsByBrokerId

        public async Task<List<ExDeclaration>> GetExDecAccountBalanceByExDecId()
        {
            return await _context.ExDeclarations
                .Where(entity =>!entity.IsSold)
                .OrderBy(x=>x.CreateDate)
                .ToListAsync();
        }

        #endregion

        #endregion


    }
}