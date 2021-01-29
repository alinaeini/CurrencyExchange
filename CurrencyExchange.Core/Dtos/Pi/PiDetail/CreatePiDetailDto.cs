using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Core.Dtos.Pi.PiDetail
{
    public class CreatePiDetailDto
    {
        #region Properties

        [Display(Name = "مبلغ واریزی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long DepositPrice { get; set; }

        [Display(Name = "تاریخ واریزی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DepositDate { get; set; }

        #endregion

        #region Relations

        public long PiId { get; set; }
        public long BrokerId { get; set; }
        #endregion



    }
}



