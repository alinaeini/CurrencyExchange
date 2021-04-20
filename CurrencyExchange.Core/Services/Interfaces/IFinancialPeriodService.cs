using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Company;

namespace CurrencyExchange.Application.Services.Interfaces
{
    public interface IFinancialPeriodService : IDisposable
    {
        public Task<List<FinancialPeriodDto>> GetFinancialList();

        public Task<FinancialPeriodDto> GetById(long toInt64);
    }
}