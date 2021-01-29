using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Ioc.Extentions.Cors
{
    public static class CorsExtention
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("EnableCorsEx", builder =>
                {
                    builder.SetIsOriginAllowed(_ => true)
                        //.AllowAnyOrigin()
                        //.SetIsOriginAllowed(origin => true)
                        .WithOrigins("https://localhost:5001")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .Build();
                });
            });
            return service;
        }
    }
}
