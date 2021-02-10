using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CurrencyExchange.Domain.EntityModels.Common;

namespace CurrencyExchange.Domain.EntityModels.Access
{
    public class Role:BaseEntity
    {
        #region Properties
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Name { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        #endregion

        #region Relations
        //[ForeignKey("UserRoleId")]
        public ICollection<UserRole> UserRoles { get; set; }

        #endregion
    }
}
