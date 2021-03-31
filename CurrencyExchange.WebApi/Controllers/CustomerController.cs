using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CurrencyExchange.Application.Utilities.Common;
using CurrencyExchange.Core.Dtos.Customer;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Common;
using CurrencyExchange.WebApi.Controllers.Base;

namespace CurrencyExchange.WebApi.Controllers
{
    public class CustomerController : AppBaseController
    {
        #region Constructor

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion

        #region Create Customer

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto customer)
        {
            if (ModelState.IsValid)
            {
                var res = await _customerService.Create(customer);
                switch (res)
                {
                    case CustomerResult.CustomerIsExist:
                        return JsonResponseStatus.Error(new {Info = "مشتری مورد نظر , قبلا در سیستم ثبت شده"});
                }
            }

            return JsonResponseStatus.Success();
        }

        #endregion

        #region Filter Customers

        [HttpGet("filter-customers")]
        public async Task<IActionResult> GetCustomers([FromQuery] FilterCustomerDto filterCustomerDto)
        {
            //filterProductDto.TakeEntity = 3;
            var customers = await _customerService.GetCustomersByFiltersList(filterCustomerDto);
            //await Task.Delay(2000);
            return JsonResponseStatus.Success(customers);
        }

        #endregion

        #region Edit Customer

        [HttpPost("edit-customer")]
        public async Task<IActionResult> EditUser([FromBody] CustomerDto customerDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = await _customerService.EditCustomerInfo(customerDto);
                switch (result)
                {
                    case CustomerResult.CanNotUpdate:
                        return JsonResponseStatus.Error(new {info = "مشتری ویرایش نشد "});
                }
            }

            return JsonResponseStatus.Success();
        }


        [HttpGet("edit-customer-get/{id}")]
        public async Task<IActionResult> GetEditUserById(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                long customerId = long.Parse(id);
                var customer = await _customerService.GetCustomerById(customerId);
                return JsonResponseStatus.Success(customer);
            }

            return JsonResponseStatus.Error(new {info = "مشتری ویرایش نشد "});
        }

        #endregion

        #region GetCustomerList

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomerList()
        {
            if (User.Identity.IsAuthenticated)
            {
                var customerList = await _customerService.GetCustomers();
                return JsonResponseStatus.Success(customerList);
            }

            return JsonResponseStatus.Error(new {info = "هیچ مشتری ارزی دریافت نشد "});
        }

        #endregion

        #region Delete

        [HttpGet("delete-customer/{id}")]
        public async Task<IActionResult> DeleteCustomerById(string id)
        {
            var customer = CustomerResult.Success;
            if (User.Identity.IsAuthenticated)
            {
                long customerId = long.Parse(id);
                customer = await _customerService.DeleteCustomerInfo(customerId);
                switch (customer)
                {
                    case CustomerResult.CanNotDelete:
                        return JsonResponseStatus.Error(new {info = "مشتری حذف نشد "});
                }
            }

            return JsonResponseStatus.Success(customer);
        }

        #endregion
    }
}