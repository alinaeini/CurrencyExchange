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
                    //builder.SetIsOriginAllowed(_ => true)
                    //.AllowAnyOrigin()
                    ////.SetIsOriginAllowed(origin => true)
                    //.WithOrigins("http://localhost:7075")
                    //.AllowAnyHeader()
                    //.AllowAnyMethod()
                    //.AllowCredentials()
                    //.Build();


                    builder.SetIsOriginAllowed(_ => true)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .Build();
                    //builder.AllowAnyOrigin()
                    //    .AllowAnyMethod()
                    //    .AllowAnyHeader();
                    //.Build();
                });
            });
            return service;
        }
    }
}
