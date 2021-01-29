using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Core.Dtos.Pi
{
    public class PiDto
    {
        #region Properties
        public long Id { get; set; }

        [Display(Name = "PI کد")]
        public string PiCode { get; set; }

        [Display(Name = "PI تاریخ")]
        public DateTime PiDate { get; set; }
        [Display(Name = "مبلغ درهم پایه ")]
        public long BasePrice { get; set; }

        [Display(Name = "مبلغ کل فروش رفته ")]
        public long TotalPrice { get; set; }


        #endregion
    }
}