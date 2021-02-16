namespace CurrencyExchange.Core.Dtos.Account.RolePermissions
{
    public class RolePermissionItem
    {
        public string DisplayTitle { get; set; }
        public long Level { get; set; }
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public bool Selected { get; set; }
    }
}