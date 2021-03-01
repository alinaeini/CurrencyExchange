using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using CurrencyExchange.Infrastructure.Data_Base.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data_Base.Repositories
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


        public async Task<CurrencySale> 
            GetCurrencyByIdIncludesCustomerAndBroker(long currSaleId)
        {
            return await _context.CurrencySales
                .Include(x => x.Customer)
                .Include(x => x.Broker)
                .SingleOrDefaultAsync(x => x.Id == currSaleId);
        }

        public async Task<long> GetTotalCurrencyByCustomerId(long customerId)
        {
            return await _context.CurrencySales.Where(x => x.CustomerId == customerId).SumAsync(x => x.SalePrice);
        }

        #endregion



    }
}