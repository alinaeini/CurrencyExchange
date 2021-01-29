using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.EntityModels.Sales;

//using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
//using CurrencyExchange.Domain.EntityModels.Sales;

namespace CurrencyExchange.Domain.EntityModels.Broker
{
    public class Broker:BaseEntity
    {
        #region Properties

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Description { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Address { get; set; }


        [Display(Name = "آیا در سیستم فعال است")]
        [MaxLength(500,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public bool IsActive { get; set; }

        [Display(Name = "نرخ کارمزد تو حسابی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType("decimal(6 ,3)")]
        public decimal ServiceChargeAccount { get; set; }

        [Display(Name = "نرخ کارمزد نقدی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType("decimal(6 ,3)")]
        public decimal ServiceChargeCash { get; set; }

        [Display(Name = "موجودی")]
        public long? AmountBalanceBroker { get; set; }

        //public long PeroformaInvoiceDetailId { get; set; }

        #endregion

        #region Relations

        public ICollection<PeroformaInvoiceDetail> PeroformaInvoiceDetails { get; set; }
        public ICollection<CurrencySale> CurrencySales { get; set; }

        #endregion

    }
}
