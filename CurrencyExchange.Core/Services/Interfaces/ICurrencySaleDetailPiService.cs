using System;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Sales.CurrencySaleExDec;
using CurrencyExchange.Core.Dtos.Sales.CurrencySalePi;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface ICurrencySaleDetailPiService : IDisposable
    {
        public Task<FilterCurrSalePiDto> GetListExDecSalesByPiDetailId(FilterCurrSalePiDto filterDto);
        public Task<FilterCurrSalePiDto> GetListPiSalesByCurrencyId(FilterCurrSalePiDto filterDto);
    }
}