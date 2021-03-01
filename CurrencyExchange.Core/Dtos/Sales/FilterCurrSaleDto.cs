using System;
using System.Collections.Generic;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Sales.CurrencySalePi;
using CurrencyExchange.Core.Dtos.Sales.Interfaces;

namespace CurrencyExchange.Core.Dtos.Sales
{
   
    public class FilterCurrSaleDto : FilterGenericDto<CurrencySaleDto> ,IFilterCurrSaleDto
    {
        public long BrokerId { get; set; }
        public long CustomerId { get; set; }
        public bool IsCashed { get; set; }
        public bool IsAccount { get; set; }
        //public bool IsProfitAmount { get; set; }
        //public bool IsLossAmount { get; set; }
        public string FromDateSale { get; set; }
        public string ToDateSale { get; set; }
        public long FromSaleBasePrice { get; set; }
        public long ToSaleBasePrice { get; set; }
    }
}