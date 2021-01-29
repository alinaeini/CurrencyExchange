using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CurrencyExchange.Domain.EntityModels.Common;

namespace CurrencyExchange.Domain.EntityModels.PeroformaInvoices
{
    public class PeroformaInvoice : BaseEntity
    {
        #region Properties

        [Display(Name = "PI کد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string PiCode { get; set; }

        [Display(Name = "PI تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public DateTime PiDate { get; set; }

        [Display(Name = "مبلغ کل فروش رفته ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        //جمع کل مبلغ PI
        public long TotalPrice { get; set; }

        [Display(Name = "مبلغ درهم پایه ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public long BasePrice { get; set; }

        public bool IsSold { get; set; }
        #endregion

        #region Relations

        public ICollection<PeroformaInvoiceDetail> PeroformaInvoiceDetails { get; set; }

        #endregion
    }
}
