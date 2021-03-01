using System;

namespace CurrencyExchange.Core.Dtos.Sales.Interfaces
{
    public interface IFilterCurrSaleDto
    {
        public long BrokerId { get; set; }
        public long CustomerId { get; set; }
        public Boolean IsCashed { get; set; }
        public Boolean IsAccount { get; set; }
        //public Boolean IsProfitAmount { get; set; }
        //public Boolean IsLossAmount { get; set; }
        public string FromDateSale { get; set; }
        public string ToDateSale { get; set; }
        public long FromSaleBasePrice { get; set; }
        public long ToSaleBasePrice { get; set; }

    }
}