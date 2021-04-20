using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface ICurrencySaleRepository:IGenericRepository<CurrencySale>
    {
        public Task<CurrencySale> GetCurrencyByIdIncludesCustomerAndBroker(long currSaleId);
        public Task<CurrencySale> GetCurrencyByIdIncludesBroker(long currSaleId);
        public Task<long> GetTotalCurrencyByCustomerId(long customerId ,long financialPeriodId);
    }
}