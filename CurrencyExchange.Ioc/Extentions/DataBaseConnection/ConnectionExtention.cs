using CurrencyExchange.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Ioc.Extentions.DataBaseConnection
{
    public static class ConnectionExtention
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<CurrencyExchangeDbContext>(options =>
            {
                var connectionString = "ConnectionStrings:ExchangeCurrConnection:Development";
                options.UseSqlServer(configuration[connectionString]);
            });
            return service;
        }
    }
}
