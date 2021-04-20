using System.Linq;
using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class MiscellaneousCustomerRepository : GenericRepository<MiscellaneousCustomer>, IMiscellaneousCustomerRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public MiscellaneousCustomerRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region MiscellaneousCustomer Related Methods

        public bool IsNameExist(string name)
        {
            var isExist = _context.MiscellaneousCustomers.Any(x => x.Name == name);
            return isExist;
        }

        #endregion


    }
}