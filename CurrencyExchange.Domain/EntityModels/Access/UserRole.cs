using System;
using System.Collections.Generic;
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

        public Role Role { get; set; }
        public User User { get; set; }
        #endregion

    }
}
