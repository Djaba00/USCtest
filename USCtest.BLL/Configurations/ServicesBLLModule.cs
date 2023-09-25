using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using USCtext.DAL.ApplicationContext;
using USCtext.DAL.Entities;

namespace USCtest.BLL.Configurations
{
    public static class ServicesBLLModule
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            return services;
        }

        /// <summary>
        /// Внедрение зависимости для базы SqLite, clientProjectName передается для миграций
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="clientProjectName"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqLiteContext(this IServiceCollection services, string connectionString, string clientProjectName)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlite(connectionString,
                opts => opts.MigrationsAssembly(clientProjectName)))
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<ApplicationContext>();

            return services;
        }
    }
}
