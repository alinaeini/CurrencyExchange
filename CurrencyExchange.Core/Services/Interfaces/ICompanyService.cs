using System;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Company;
using CurrencyExchange.Domain.EntityModels.FinancialPeriod;

namespace CurrencyExchange.Application.Services.Interfaces
{
    public interface ICompanyService : IDisposable
    {
        public Task<CompanyDto> GetCompanyInfo();

    }
}