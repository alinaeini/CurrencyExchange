using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Customer;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Sequrity;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.Domain.EntityModels.Customers;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        #region Costructor

        private ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        #endregion

        #region Customer Methods

        #region Create

        public async Task<CustomerResult> Create(CreateCustomerDto customerDto)
        {
            var IsExist = customerRepository.IsNameExist(customerDto.Name.Trim().ToLower());
            if (IsExist)
                return CustomerResult.CustomerIsExist;
            var customer = new Customer()
            {
                Title = customerDto.Title.SanitizeText().Trim(),
                Address = customerDto.Address.SanitizeText().Trim(),
                Description = customerDto.Description.SanitizeText().Trim(),
                Name = customerDto.Name.SanitizeText().Trim(),
                Phone = customerDto.Phone.SanitizeText().Trim()
            };
            await customerRepository.AddEntity(customer);
            await customerRepository.SaveChanges();
            return CustomerResult.Success;
        }

        #endregion

        #region Filter By Name Or Ttitle

        public async Task<FilterCustomerDto> GetCustomersByFiltersList(FilterCustomerDto filterCustomerDto)
        {
            var cuastomerList = customerRepository.GetEntities().AsQueryable();

            if (filterCustomerDto.SearchText != null || !(string.IsNullOrEmpty(filterCustomerDto.SearchText)))
            {
                cuastomerList = cuastomerList.Where(x => x.Title.Contains(filterCustomerDto.SearchText.Trim()) ||
                                                         x.Name.Contains(filterCustomerDto.SearchText.Trim()));
            }

            var count = (int)Math.Ceiling(cuastomerList.Count() / (double)filterCustomerDto.TakeEntity);
            var pager = Pager.Builder(count, filterCustomerDto.PageId, filterCustomerDto.TakeEntity);
            var customers = await cuastomerList.Paging(pager).ToListAsync();
            filterCustomerDto.CustomerDtos = new List<CustomerDto>();
            foreach (var item in customers)
            {
                filterCustomerDto.CustomerDtos.Add(new CustomerDto
                {
                    Title = item.Title.SanitizeText(),
                    Name = item.Name.SanitizeText(),
                    Phone = item.Phone.SanitizeText(),
                    Address = item.Address.SanitizeText(),
                    Description = item.Description.SanitizeText(),
                    Id = item.Id
                });
            }

            return filterCustomerDto.SetCustomer(filterCustomerDto.CustomerDtos).SetPaging(pager);
        }

        #endregion

        #region Get customer By ID

        public async Task<CustomerDto> GetCustomerById(long id)
        {
            var customer = await customerRepository.GetEntityById(id);
            if (customer == null)
            {
                return null;
            }
            return new CustomerDto
            {
                Id = customer.Id,
                Address = customer.Address,
                Description = customer.Description,
                Name = customer.Name,
                Phone = customer.Phone,
                Title = customer.Title
            };
        }



        #endregion

        #region GetCustomers

        public async Task<List<CustomerDto>> GetCustomers()
        {
            List<CustomerDto> cutomerList = new List<CustomerDto>();
            var customers = await customerRepository.GetEntities().ToListAsync();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    cutomerList.Add(new CustomerDto
                    {
                        Id = customer.Id,
                        Address = customer.Address,
                        Description = customer.Description,
                        Name = customer.Name,
                        Phone = customer.Phone,
                        Title = customer.Title
                    });
                }
            }

            return cutomerList;
        }

        #endregion

        #region Edit

        public async Task<CustomerResult> EditCustomerInfo(CustomerDto customerDto)
        {
            var customer = await customerRepository.GetEntityById(customerDto.Id);
            if (customer == null)
                return CustomerResult.CanNotUpdate;
            customer.Address = customerDto.Address.SanitizeText().Trim();
            customer.Description = customerDto.Description.SanitizeText().Trim();
            customer.Name = customerDto.Name.SanitizeText().Trim();
            customer.Phone = customerDto.Phone.SanitizeText().Trim();
            customer.Title = customerDto.Title.SanitizeText().Trim();
            customerRepository.UpdateEntity(customer);
            await customerRepository.SaveChanges();
            return CustomerResult.Success;
        }

        #endregion

        #region Delete

        public async Task<CustomerResult> DeleteCustomerInfo(long Id)
        {
            await customerRepository.RemoveEntity(Id);
            await customerRepository.SaveChanges();
            return CustomerResult.Success;
        }

        #endregion

        #endregion

        #region Dispose

        public void Dispose()
        {
            this.customerRepository?.Dispose();
        }



        #endregion

    }
}