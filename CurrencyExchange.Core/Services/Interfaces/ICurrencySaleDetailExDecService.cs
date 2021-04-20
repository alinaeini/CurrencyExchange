using System;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Sales.CurrencySaleExDec;
using CurrencyExchange.Core.Dtos.Sales.CurrencySaleExDec;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface ICurrencySaleDetailExDecService : IDisposable
    {
        public Task<FilterCurrSaleExDecDto> GetListExDecSalesByExdecId(FilterCurrSaleExDecDto filterDto);
        public Task<FilterCurrSaleExDecDto> GetListExDecSalesByCurrencyId(FilterCurrSaleExDecDto filterPiDto);
    }
}