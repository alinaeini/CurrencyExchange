using System.IO;
using System.Text;
using CurrencyExchange.Ioc.Extentions.Authentication;
using CurrencyExchange.Ioc.Extentions.Cors;
using CurrencyExchange.Ioc.Extentions.DataBaseConnection;
using CurrencyExchange.Ioc.Extentions.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;


namespace CurrencyExchange.WebApi
{
    public class Startup
    {
        #region Constructor

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json")
                    .Build()
            );

            
            #region Application Services

            services.RegisterServices();

            #endregion

            #region Add DbContext

            services.AddApplicationDbContext(Configuration);

            #endregion

            #region Authentication

            services.AddAuthenticationAndJwtBearer();

            #endregion

            #region CORS

            services.AddCorsPolicy();

            #endregion
            //services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
             }

            #region Set LicenseKey StimulSoft

            var contentRoot = env.ContentRootPath;
            var licenseFile = System.IO.Path.Combine(contentRoot, "wwwroot\\Reports", "license.key");
            Stimulsoft.Base.StiLicense.LoadFromFile(licenseFile);

            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("EnableCorsEx");
            app.UseAuthentication();
            app.UseAuthorization();

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
            //    await next();
            //    await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Broker}/{action=brokers}/{id?}");
            });
        }
    }
}