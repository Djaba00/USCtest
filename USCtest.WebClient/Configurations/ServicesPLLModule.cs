using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using USCtest.BLL.Interfaces;
using USCtest.BLL.Services;

namespace USCtest.WebClient.Configurations
{
    public static class ServicesPLLModule
    {
        public static IServiceCollection AddPLLServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<ITaxService, TaxService>();

            return services;
        }
    }
}
