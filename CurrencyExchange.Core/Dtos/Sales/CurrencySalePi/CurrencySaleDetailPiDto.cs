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

        public long CurrencySaleId { get; set; }
        public long PeroformaInvoiceDetailId { get; set; }



        #endregion

    }
}