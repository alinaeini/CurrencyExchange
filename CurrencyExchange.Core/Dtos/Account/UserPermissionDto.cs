using System.Collections.Generic;

namespace CurrencyExchange.Core.Dtos.Account
{
    public class UserPermissionDto
    {
        public string ParentName { get; set; }
        public List<UserRolePermissionDto> DetaiList { get; set; }
    }
}