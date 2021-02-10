using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CurrencyExchange.Domain.EntityModels.Broker;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.EntityModels.Customers;

namespace CurrencyExchange.Domain.EntityModels.Sales
{
    public class CurrencySale:BaseEntity
    {
        #region Properties



        [Display(Name = " تاریخ فروش ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "مقدار ارز فروش رفته ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public long SalePrice { get; set; }

        [Display(Name = "نرخ فروش ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long SalePricePerUnit { get; set; }

        [Display(Name = "نوع انتقال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public CurrencyTransferType TransferType { get; set; }

        [Display(Name = "کارمزد انتقال ارز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long TransferPrice { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Description { get; set; }
        
        public long BrokerId { get; set; }
       
        public long CustomerId { get; set; }

        #endregion

        #region Relatoins
        public ICollection<CurrencySaleDetailExDec> CurrencySaleDetailExDecs { get; set; }
        public ICollection<CurrencySaleDetailPi> CurrencySaleDetailPies { get; set; }

        [ForeignKey("BrokerId")]
        public  Broker.Broker Broker { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        #endregion
    }

    public enum CurrencyTransferType
    {
        Cash,
        Accounting
    }
}
