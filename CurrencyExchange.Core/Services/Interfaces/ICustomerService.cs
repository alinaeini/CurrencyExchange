using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Customer;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface ICustomerService:IDisposable
    {
        Task<CustomerResult> Create(CreateCustomerDto customerDto);
        Task<FilterCustomerDto> GetCustomersByFiltersList(FilterCustomerDto filterCustomerDto);
        Task<CustomerDto> GetCustomerById(long id);
        Task<List<CustomerDto>> GetCustomers();
        Task<CustomerResult> EditCustomerInfo(CustomerDto customerDto);
        Task<CustomerResult> DeleteCustomerInfo(long Id);
    }
}
