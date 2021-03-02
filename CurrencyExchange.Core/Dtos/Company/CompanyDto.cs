using System.ComponentModel.DataAnnotations;
using CurrencyExchange.Domain.EntityModels.Common;

namespace CurrencyExchange.Core.Dtos.Company
{
    public class CompanyDto 
    {
        [Display(Name = "نام شرکت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string CompanyName { get; set; }


        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Tel { get; set; }

        [Display(Name = "وب سایت")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string WebSite { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Address { get; set; }
    }
}