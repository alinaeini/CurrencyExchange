using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Customer;
using CurrencyExchange.Core.Dtos.Customer;

namespace CurrencyExchange.Application.Services.Interfaces
{
    public interface ICommodityCustomerService : IDisposable
    {
        Task<CustomerResult> Create(CreateCustomerDto customerDto);
        Task<FilterCustomerDto> GetCustomersByFiltersList(FilterCustomerDto filterCustomerDto);
        Task<CustomerDto> GetCustomerById(long id);
        Task<List<CustomerDto>> GetCustomers();
        Task<CustomerResult> EditCustomerInfo(CustomerDto customerDto);
        Task<CustomerResult> DeleteCustomerInfo(long Id);
    }
}