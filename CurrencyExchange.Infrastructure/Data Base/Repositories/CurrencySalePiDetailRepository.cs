using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class CurrencySalePiDetailRepository : GenericRepository<CurrencySaleDetailPi>, ICurrencySalePiDetailRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;

        public CurrencySalePiDetailRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Sum Performa Invoice Code in per  Sales Used 

        public async Task<long> GetSumPiCodeUsedById(long piId)
        {
            //var financial = await _context.FinancialPeriods.FirstOrDefaultAsync(x => x.Id == financialPeriodId);
            return await _context.CurrencySaleDetailPis
                .Where(entity => entity.PeroformaInvoiceDetailId == piId)
                                 //&& (entity.CurrencySale.SaleDate >= financial.FromDate && entity.CurrencySale.SaleDate < financial.ToDate))
                .SumAsync(entity => entity.Price);
        }

        public async Task<long> GetSumProfitLost(long currId)
        {
            //var financial = await _context.FinancialPeriods.FirstOrDefaultAsync(x => x.Id == financialPeriodId);
            return await _context.CurrencySaleDetailPis 
                .Include(x=>x.CurrencySale)
                .Where(entity => entity.CurrencySaleId == currId )
                    //&& (entity.CurrencySale.SaleDate >= financial.FromDate && entity.CurrencySale.SaleDate < financial.ToDate))
                .SumAsync(entity => entity.ProfitLossAmount);
        }
        public async Task<long> GetSumProfitLost(long currId,long financialPeriodId)
        {
            var financial = await _context.FinancialPeriods.FirstOrDefaultAsync(x => x.Id == financialPeriodId);
            return await _context.CurrencySaleDetailPis
                .Include(x => x.CurrencySale)
                .Where(entity => entity.CurrencySaleId == currId
                && (entity.CurrencySale.SaleDate >= financial.FromDate && entity.CurrencySale.SaleDate < financial.ToDate))
                .SumAsync(entity => entity.ProfitLossAmount);
        }

        #endregion
    }
}