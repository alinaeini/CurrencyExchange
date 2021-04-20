using System;
using System.Security.Claims;

namespace CurrencyExchange.Application.Utilities.Extensions
{
    public static class IdentityGeFinancialPeriodExtention
    {
        public static long GeFinancialPeriodId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var financialPeriodId = claimsPrincipal.FindFirst(ClaimTypes.SerialNumber);
                return Convert.ToInt64(financialPeriodId.Value);
            }
            return default(long);
        }
    }
}