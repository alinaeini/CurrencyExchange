using CurrencyExchange.Core.Sequrity;
using CurrencyExchange.Core.Services.Implementations;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Convertors;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data_Base.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Ioc.Extentions.Service
{
    public static class DependencyContainerExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service)
        {


            #region Application(Core) Layer Dependancies

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<IPiService, PiService>();
            service.AddScoped<IPiDetailService, PiDetailService>();
            service.AddScoped<IBrokerService, BrokerService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IPasswordHelper, PasswordHelper>();
            service.AddScoped<IMailSender, SendEmail>();
            service.AddScoped<IExDeclarationService, ExDeclarationService>();
            service.AddScoped<ICurrencySaleService, CurrencySaleService>();
            service.AddScoped<ICurrencySaleDetailExDecService, CurrencySaleDetailExDecService>();
            service.AddScoped<ICurrencySaleDetailPiService, CurrencySaleDetailPiService>();
            service.AddScoped<IViewRenderService, RenderViewToString>();
            

            #endregion

            #region Data Layer Dependancies

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserRoleRepository, UserRoleRepository>();
            service.AddScoped<IUserRolePermissionRepository, UserRolePermissionRepository>();
            service.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            service.AddScoped<IPiRepository, PiRepository>();
            service.AddScoped<IPiDetailRepository, PiDetailRepository>();
            service.AddScoped<IBrokerRepository, BrokerRepository>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<IExDeclarationRepository, ExDeclarationRepository>();
            service.AddScoped<ICurrencySaleRepository, CurrencySaleRepository>();
            service.AddScoped<ICurrencySalePiDetailRepository, CurrencySalePiDetailRepository>();
            service.AddScoped<ICurrencySaleExDecRepository, CurrencySaleExDecRepository>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();
            #endregion

            return service;
        }



    }
}
