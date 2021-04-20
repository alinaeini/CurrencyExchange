using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IMiscellaneousCustomerRepository : IGenericRepository<MiscellaneousCustomer>
    {
        bool IsNameExist(string name);
    }
}