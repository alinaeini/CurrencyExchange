using System;
using System.Security.Claims;

namespace CurrencyExchange.Application.Utilities.Extensions
{
    public static class IdentityUserExtention
    {
        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var userID = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
                return Convert.ToInt64(userID.Value);
            }
            return default(long);
        }


    }
}
 

