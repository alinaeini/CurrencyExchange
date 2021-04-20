using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface ICommodityCustomerRepository : IGenericRepository<CommodityCustomer>
    {
        bool IsNameExist(string toLower);
    }
}