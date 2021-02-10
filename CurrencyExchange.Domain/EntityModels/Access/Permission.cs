using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CurrencyExchange.Domain.EntityModels.Common;

namespace CurrencyExchange.Domain.EntityModels.Access
{
    public class Permission : BaseEntity
    {
        [Display(Name = " نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string PersianName { get; set; }

        [Display(Name = "لینک دسترسی")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string AccessLink { get; set; }

        public long? ParentId { get; set; }
        public  Permission Parent { get; set; }
        public ICollection<UserRolePermission> RolePermissions { get; set; }
    }


}