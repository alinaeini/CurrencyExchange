using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IPiDetailRepository : IGenericRepository<PeroformaInvoiceDetail>
    {
        public Task<long> SumPayDetails(long id);
        //جمع مانده حساب کارگزار
        public Task<long> GetSumBrokerAccountBalance(long brokerId);

        //لیست مانده حساب کارگزار
        public Task<List<PeroformaInvoiceDetail>> GetAccountBalanceByDetailsByBrokerId(long brokerId);

        public Task<bool> SoldedPiDetail(long id);

    }
}