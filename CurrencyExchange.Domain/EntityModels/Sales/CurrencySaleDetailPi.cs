using System.ComponentModel.DataAnnotations;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;

namespace CurrencyExchange.Domain.EntityModels.Sales
{
    public class CurrencySaleDetailPi : BaseEntity
    {
        #region Properties

        [Display(Name = "مقدار ارز فروش رفته ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public long Price { get; set; }

        [Display(Name = "مقدار سود و زیان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long ProfitLossAmount { get; set; }

        public long CurrencySaleId { get; set; }
        public long? PeroformaInvoiceDetailId { get; set; }



        #endregion

        #region Relatoins

        public PeroformaInvoiceDetail PeroformaInvoiceDetails { get; set; }


        #endregion
    }
}