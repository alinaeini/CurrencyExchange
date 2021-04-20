using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CurrencyExchange.Infrastructure.Ioc.Extentions.DataBaseConnection
{
    public static class ConnectionExtention
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<CurrencyExchangeDbContext>(options =>
            {
                var connectionString = "ConnectionStrings:ExchangeCurrConnection:Development";
                options
                    .UseLoggerFactory(DatabaseLoggerFactory)
                    .UseSqlServer(configuration[connectionString]);
            });
            return service;
        }

        public static readonly ILoggerFactory DatabaseLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
