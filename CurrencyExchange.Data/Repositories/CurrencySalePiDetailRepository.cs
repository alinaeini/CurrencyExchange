using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Data.Repositories.Generics;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data.Repositories
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
            return await _context.CurrencySaleDetailPis
                .Where(entity => entity.PeroformaInvoiceDetailId == piId)
                .SumAsync(entity => entity.Price);
        }

        public async Task<long> GetSumProfitLost(long currId)
        {
            return await _context.CurrencySaleDetailPis
                .Where(entity => entity.CurrencySaleId == currId)
                .SumAsync(entity => entity.ProfitLossAmount);
        }

        #endregion
    }
}