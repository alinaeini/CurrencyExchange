using System;
using System.Collections.Generic;
using System.Text;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Core.Dtos.Customer
{
    public class FilterCustomerDto : BasePaging
    {
        public string SearchText { get; set; }
        public List<CustomerDto> CustomerDtos { get; set; }

        public FilterCustomerDto SetPaging(BasePaging paging)
        {
            PageId = paging.PageId;
            PageCount = paging.PageCount;
            ActivePage = paging.ActivePage;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            TakeEntity = paging.TakeEntity;
            SkipEntity = paging.SkipEntity;
            return this;
        }

        public FilterCustomerDto SetCustomer(List<CustomerDto> customers)
        {
            this.CustomerDtos = customers;
            return this;
        }
    }
}