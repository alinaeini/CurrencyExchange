using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {
        bool IsNameExist(string name);
    }
}