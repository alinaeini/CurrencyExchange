using System;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Customer;
using CurrencyExchange.Application.Dtos.Sales;
using CurrencyExchange.Core.Dtos.Customer;
using CurrencyExchange.Core.Dtos.Sales;

namespace CurrencyExchange.Application.Services.Interfaces
{
    public interface ICurrencySaleService :IDisposable
    {
        Task<SalesResult> Create(CreateSaleDto createPiDto);
        Task<FilterCurrSaleDto> GetListSales(FilterCurrSaleDto filterPiDto, long financialPeriodId);
        Task<FilterCurrSaleCustomerListDto> GetListSalesByCustomerId(long customerId, long financialPeriodId);
        Task<FilterCurrencyCustomerDto> GetSoldPerCustomers(FilterCurrencyCustomerDto filterDto, long financialPeriodId);
    }
}


