using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class CurrencySaleRepository : GenericRepository<CurrencySale>, ICurrencySaleRepository
    {
        #region Constructor
        private readonly CurrencyExchangeDbContext _context;
        public CurrencySaleRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region CurrencySale Related Methods


        public async Task<CurrencySale> GetCurrencyByIdIncludesCustomerAndBroker(long currSaleId)
        {
            //var financial = await _context.FinancialPeriods.FirstOrDefaultAsync(x => x.Id == financialPeriodId);
            return await _context.CurrencySales
                .Include(x => x.Customer)
                .Include(x => x.Broker)
                //.Where(x=> (x.SaleDate >= financial.FromDate && x.SaleDate < financial.ToDate))
                .SingleOrDefaultAsync(x => x.Id == currSaleId);
        }

        public async Task<CurrencySale> GetCurrencyByIdIncludesBroker(long currSaleId)
        {
            //var financial = await _context.FinancialPeriods.FirstOrDefaultAsync(x => x.Id == financialPeriodId);
            return await _context.CurrencySales
                .Include(x => x.Broker)
                //.Where(x => (x.SaleDate >= financial.FromDate && x.SaleDate < financial.ToDate))
                .SingleOrDefaultAsync(x => x.Id == currSaleId);
        }

        public async Task<long> GetTotalCurrencyByCustomerId(long customerId, long financialPeriodId)
        {
            var financial =await _context.FinancialPeriods.FirstOrDefaultAsync(x => x.Id == financialPeriodId);
            return await _context.CurrencySales.Where(x => x.CustomerId == customerId &&
                                                           (x.SaleDate >= financial.FromDate && x.SaleDate < financial.ToDate))
                .SumAsync(x => x.SalePrice);
        }

        #endregion



    }
}