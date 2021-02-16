using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Core.Dtos.Account
{
    public class PermissionDto
    {
        [Display(Name = " نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string DisplayTitle { get; set; }
        public long? ParentId{ get; set; }
        public long Id { get; set; }

        public bool Selected { get; set; }

        public long UserId { get; set; }

    }
}