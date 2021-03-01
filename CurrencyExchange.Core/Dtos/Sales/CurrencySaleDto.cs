using System;
using System.ComponentModel.DataAnnotations;
using CurrencyExchange.Domain.EntityModels.Sales;

namespace CurrencyExchange.Core.Dtos.Sales
{
    public class CurrencySaleDto
    {

        #region Properties

        public long Id { get; set; }

        [Display(Name = "مقدار ارز فروش رفته ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public long Price { get; set; }
        [Display(Name = "مقدار سود و زیان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long ProfitLossAmount { get; set; }


        public DateTime CurrSaleDate { get; set; }
        public string BrokerName { get; set; }
        public string CustomerName { get; set; }

        [Display(Name = "نرخ فروش ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long SalePricePerUnit { get; set; }

  

        [Display(Name = "کارمزد انتقال ارز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long TransferPrice { get; set; }

        [Display(Name = "نوع انتقال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public CurrencyTransferType TransferType { get; set; }



        #endregion

    }
}