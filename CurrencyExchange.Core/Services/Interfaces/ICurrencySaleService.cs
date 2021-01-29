using System;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Sales;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface ICurrencySaleService :IDisposable
    {
        Task<SalesResult> Create(CreateSaleDto createPiDto);
    }
}


