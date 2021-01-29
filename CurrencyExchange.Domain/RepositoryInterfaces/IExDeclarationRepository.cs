using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.ExchangeDeclaration;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IExDeclarationRepository:IGenericRepository<ExDeclaration>
    {
        public bool IsCodeExist(string exCode);

        //جمع مانده اظهارنامه
        public Task<long> GetSumExDecAccountBalance();

        //لیست مانده حساب اظهارنامه
        public Task<List<ExDeclaration>> GetExDecAccountBalanceByExDecId();
        public Task<bool> SoldedDeclaration(long id);

       
    }
}
