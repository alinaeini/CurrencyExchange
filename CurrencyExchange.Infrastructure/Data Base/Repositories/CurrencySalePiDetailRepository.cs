using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using CurrencyExchange.Infrastructure.Data_Base.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data_Base.Repositories
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