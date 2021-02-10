using System.ComponentModel.DataAnnotations.Schema;
using CurrencyExchange.Domain.EntityModels.Common;

namespace CurrencyExchange.Domain.EntityModels.Access
{
    public class UserRolePermission : BaseEntity
    {
        #region Properties

        public long UserRoleId { get; set; }

        public long PermissionId { get; set; }

        //[Display(Name = " منوی اصلی / زیرمنو")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        //public bool IsMenu { get; set; }

        //[Display(Name = " نام")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        //public string PersianName { get; set; }

        //[Display(Name = "لینک دسترسی")]
        //[MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        //public string AccessLink { get; set; }
        #endregion
        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }

        [ForeignKey("UserRoleId")]
        public UserRole UserRole { get; set; }

    }
}