using System;

namespace CurrencyExchange.Core.Dtos.Sales.CurrencySaleExDec
{
    public class CurrencySaleExDecDto
    {
        public long Id { get; set; }
        public DateTime CurrSaleDate { get; set; }
        public long Price { get; set; }

        public string ExDecCode { get; set; }
        public string BrokerName { get; set; }
        public string CustomerName { get; set; }
        public long ExDecPrice { get; set; }
    }
}