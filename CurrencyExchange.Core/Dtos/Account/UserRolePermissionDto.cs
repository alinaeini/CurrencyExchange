using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Core.Dtos.Account
{
    public class UserRolePermissionDto
    {
        [Display(Name = " نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string PersianName { get; set; }

        //[Display(Name = " منوی اصلی / زیرمنو")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]


        [Display(Name = "لینک دسترسی")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string AccessLink { get; set; }
    }
}