﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;

namespace CurrencyExchange.Domain.EntityModels.Customers
{
    public class CommodityCustomer : BaseEntity
    {
        #region Properties

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Name { get; set; }
        [Display(Name = "شهرت")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Phone { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Address { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Description { get; set; }

        //public long CurrencySaleId { get; set; }
        #endregion

        public ICollection<PeroformaInvoice> PeroformaInvoices  { get; set; }

    }
}