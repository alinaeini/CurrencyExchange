using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Broker;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IBrokerRepository:IGenericRepository<Broker>
    {
        Task<Broker> GetByName(string name);
        Task<Broker> GetByTitle(string title);
        bool IsBrokerExistByName(string name);
        bool IsBrokerExistByTitle(string title);

        Task<bool> UpdateBrokerAmount(long brokerId, long price, bool isAdd);
    }
}
