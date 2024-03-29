﻿using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Application.Dtos.Account
{
    public class LoginUserDto
    {

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Password { get; set; }

        public string FinancialPeriodId { get; set; }

    }
    public enum LoginUserResult
    {
        Success,
        UserAndPassAreNotValid,
        UserIsNotActive,
        UserIsNotAdmin,
        UserDoesNotHAveAnyRoles
    }
}
