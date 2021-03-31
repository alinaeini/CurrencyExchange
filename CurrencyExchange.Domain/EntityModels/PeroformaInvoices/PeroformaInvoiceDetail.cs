using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.EntityModels.Currency;

namespace CurrencyExchange.Domain.EntityModels.PeroformaInvoices
{
    public class PeroformaInvoiceDetail : BaseEntity
    {
        #region Properties
        [Display(Name = "مبلغ واریزی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long DepositPrice { get; set; }

        [Display(Name = "تاریخ واریزی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DepositDate { get; set; }

        [Display(Name = "فروش رفته")]
        public bool IsSold { get; set; }

        public long  BrokerId { get; set; }
        public long PeroformaInvoiceId { get; set; }

        #endregion

        #region Relations
        
        public PeroformaInvoice PeroformaInvoice { get; set; }
        public Broker.Broker Broker { get; set; }
        public ICollection<CurrencySaleDetailPi> CurrencySaleDetailPi { get; set; }
        #endregion
    }
}