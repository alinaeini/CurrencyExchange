using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface ICurrencySalePiDetailRepository : IGenericRepository<CurrencySaleDetailPi>
    {
        Task<long> GetSumPiCodeUsedById(long piId);
        Task<long> GetSumProfitLost(long currId);

    }
}