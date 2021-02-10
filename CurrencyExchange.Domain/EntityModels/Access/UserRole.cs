using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CurrencyExchange.Domain.EntityModels.Account;
using CurrencyExchange.Domain.EntityModels.Common;

namespace CurrencyExchange.Domain.EntityModels.Access
{
    public class UserRole:BaseEntity
    {
        #region Properties

        public long UserId { get; set; }
        public long RoleId { get; set; }


        #endregion

        #region Relations
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<UserRolePermission> UserRolePermissions { get; set; }
        #endregion

    }
}
