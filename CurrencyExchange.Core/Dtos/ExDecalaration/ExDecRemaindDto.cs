using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Application.Dtos.ExDecalaration
{
    public class ExDecRemaindDto
    {
        [Required]
        public long Id { get; set; }

        [Display(Name = "شماره سریال اظهارنامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ExCode { get; set; }

        [Display(Name = "مقدار درهم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Price { get; set; }

        [Display(Name = "مقدار تناژ")]
        public long Qty { get; set; }

        [Display(Name = "تاریخ انقضای اظهار نامه")]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "مقدار درهم فروخته شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long SoldPrice { get; set; }

        [Display(Name = "مقدار درهم باقیمانده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long RemaindPrice { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
