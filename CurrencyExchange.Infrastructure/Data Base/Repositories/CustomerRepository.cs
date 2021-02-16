using System.Linq;
using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using CurrencyExchange.Infrastructure.Data_Base.Repositories.Generics;

namespace CurrencyExchange.Infrastructure.Data_Base.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public CustomerRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Customer Related Methods

        public bool IsNameExist(string name)
        {
            var isExist = _context.Customers.Any(x => x.Name == name);
            return isExist;
        }

        #endregion


    }
}