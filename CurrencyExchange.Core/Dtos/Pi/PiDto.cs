using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Application.Dtos.Pi
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


        [Display(Name = "توضیحات")]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Description { get; set; }

        [Display(Name = "کد مشتری کالا")]
        public long CustomerId { get; set; }

        #endregion
    }
}