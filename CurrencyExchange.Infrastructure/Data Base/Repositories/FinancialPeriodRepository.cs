using CurrencyExchange.Domain.EntityModels.FinancialPeriod;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class FinancialPeriodRepository : GenericRepository<FinancialPeriod>, IFinancialPeriodRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;

        public FinancialPeriodRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion


        #region Financial Period Related Methods

        #endregion

    }
}