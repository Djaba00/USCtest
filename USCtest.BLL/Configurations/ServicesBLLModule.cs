﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using USCtest.DAL.DataContext;
using USCtest.DAL.Entities;
using USCtest.DAL.Interfaces;
using USCtest.DAL.Repositories;

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
        public static IServiceCollection AddBllServices(this IServiceCollection services, Profile profile = null)
        {
            services.AddScoped<IUnitOfWork, ContextUnitOfWork>();
                
            var mapperConfig = new MapperConfiguration((v) =>
            {
                if (profile != null)
                    v.AddProfile(profile);

                v.AddProfile(new MappingProfileBLL());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }

        /// <summary>
        /// Внедрение зависимости для базы SqLite
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="clientProjectName" - для миграций></param>
        /// <returns></returns>
        public static IServiceCollection AddSqLiteContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlite(connectionString, opt =>
                opt.MigrationsAssembly("USCtest.DAL"))
                .EnableSensitiveDataLogging())
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
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
