using CurrencyExchange.Domain.EntityModels.Company;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class CompanyRepository : GenericRepository<CompanyInfo>, ICompanyRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;

        public CompanyRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion


        #region Company Related Methods

        #endregion

    }
}