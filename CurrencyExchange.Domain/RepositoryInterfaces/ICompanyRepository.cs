using CurrencyExchange.Domain.EntityModels.Account;
using CurrencyExchange.Domain.EntityModels.Company;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface ICompanyRepository:IGenericRepository<CompanyInfo>
    {
      
    }
}