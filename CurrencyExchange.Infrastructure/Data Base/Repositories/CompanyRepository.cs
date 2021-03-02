using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Company;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using CurrencyExchange.Infrastructure.Data_Base.Repositories.Generics;

namespace CurrencyExchange.Infrastructure.Data_Base.Repositories
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