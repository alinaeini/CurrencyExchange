using System.Linq;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Data.Repositories.Generics;
using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.RepositoryInterfaces;

namespace CurrencyExchange.Data.Repositories
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