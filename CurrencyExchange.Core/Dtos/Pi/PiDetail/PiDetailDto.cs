using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Application.Dtos.Pi.PiDetail
{
    public class PiDetailDto
    {
        #region Properties
        public long Id { get; set; }

        [Display(Name = "مبلغ واریزی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long DepositPrice { get; set; }

        [Display(Name = "تاریخ واریزی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DepositDate { get; set; }

        public bool IsSold { get; set; }

        #endregion

        #region Relations

        public long PiId { get; set; }

        public long BrokerId { get; set; }

        #endregion
    }
}