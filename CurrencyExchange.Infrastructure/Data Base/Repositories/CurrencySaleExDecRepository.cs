using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class CurrencySaleExDecRepository : GenericRepository<CurrencySaleDetailExDec>, ICurrencySaleExDecRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;

        public CurrencySaleExDecRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Sum Exchange Declaration in per  Sales Used 

        public async Task<long> GetSumExCodeUsedById(long exDecId)
        {
            return await _context.CurrencySaleDetailExDecs
                .Where(entity => entity.ExDeclarationId == exDecId)
                .SumAsync(entity => entity.Price);
        }




        #region GetExDecList


        public async Task<List<CurrencySaleDetailExDec>> GetExDecList(long currSaleId, long financialPeriodId)
        {
            var financial = await _context.FinancialPeriods.FirstOrDefaultAsync(x => x.Id == financialPeriodId);
            return await _context.CurrencySaleDetailExDecs
                .Include(x=>x.CurrencySale)
                .Where(x=>x.CurrencySaleId== currSaleId &&
                           (x.CurrencySale.SaleDate >= financial.FromDate && x.CurrencySale.SaleDate < financial.ToDate))
                .ToListAsync();
        }

        #endregion
        #endregion


    }
}