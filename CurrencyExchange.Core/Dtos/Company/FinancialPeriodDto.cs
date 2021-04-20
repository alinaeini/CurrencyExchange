using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Application.Dtos.Company
{
    public class FinancialPeriodDto
    {

        public long FinancialPeriodId { get; set; }

        [Display(Name = "نام دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string PriodName { get; set; }

        [Display(Name = "از تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime FromDate { get; set; }

        [Display(Name = "تا تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime ToDate { get; set; }
    }
}