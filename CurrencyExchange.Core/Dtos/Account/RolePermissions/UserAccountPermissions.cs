using System.Collections.Generic;

namespace CurrencyExchange.Core.Dtos.Account.RolePermissions
{
    public class UserAccountPermissions
    {

        public List<UserInfoDto> UserNotRoleList { get; set; }
        public List<RolePermissionListItems> RolePermissionListItems { get; set; }

    }
}