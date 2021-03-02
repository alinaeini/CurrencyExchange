using System;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Company;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        public Task<CompanyDto> GetCompanyInfo();

    }
}