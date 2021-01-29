using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface ICurrencySaleExDecRepository : IGenericRepository<CurrencySaleDetailExDec>
    {
        Task<long> GetSumExCodeUsedById(long exDecId);

        public Task<List<CurrencySaleDetailExDec>> GetExDecList(long currSaleId);
    }
}