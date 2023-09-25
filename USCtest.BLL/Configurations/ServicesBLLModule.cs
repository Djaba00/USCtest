using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using USCtext.DAL.DataContext;
using USCtext.DAL.Entities;
using USCtext.DAL.Interfaces;
using USCtext.DAL.Repositories;

namespace USCtest.BLL.Configurations
{
    public static class ServicesBLLModule
    {
        /// <summary>
        /// Automapper + repositories
        /// </summary>
        /// <param name="services"></param>
        /// <param name="mappingProfile" - профиль automapper со столя клиента (DTO <-> VM)></param>
        /// <returns></returns>
        public static IServiceCollection AddBllServices(this IServiceCollection services, Profile mappingProfile = null)
        {
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(mappingProfile);
                v.AddProfile(new MappingProfileBLL());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);


            services.AddScoped<IUnitOfWork, ContextUnitOfWork>();

            return services;
        }

        /// <summary>
        /// Внедрение зависимости для базы SqLite
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="clientProjectName" - для миграций></param>
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
