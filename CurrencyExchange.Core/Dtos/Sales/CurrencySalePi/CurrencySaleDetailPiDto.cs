using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Core.Dtos.Sales.CurrencySalePi
{
    public class CurrencySaleDetailPiDto {

        #region Properties

        public long Id { get; set; }

        [Display(Name = "مقدار ارز فروش رفته ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public long Price { get; set; }

        [Display(Name = "مقدار سود و زیان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long ProfitLossAmount { get; set; }


        public DateTime CurrSaleDate { get; set; }
        public string PiCode { get; set; }
        public string BrokerName { get; set; }
        public string CustomerName { get; set; }
        public long PiDetailPrice { get; set; }

        public long SellPriceCurrency { get; set; }
        public long SellPriceCommodity { get; set; }

        #endregion

    }
}