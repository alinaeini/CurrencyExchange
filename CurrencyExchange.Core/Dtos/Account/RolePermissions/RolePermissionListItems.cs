using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.Core.Dtos.Account.RolePermissions
{
    public class RolePermissionListItems
    {
        public long UserId { get; set; }
        public List<RolePermissionItem> PermissionFlatNode { get; set; }

    }
}
