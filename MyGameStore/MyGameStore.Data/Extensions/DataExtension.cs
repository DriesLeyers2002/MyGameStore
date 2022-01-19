using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyGameStore.Data.Context;
using MyGameStore.Data.Repositories;
using MyGameStore.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.Data.Extensions
{
    public static class DataExtension
    {
        public static IServiceCollection RegistratorDataAccessServices(this IServiceCollection services)
        {
            services.RegistratorContext();
            services.RegistratorRepositories();
            services.RegistratorUnitOfWorks();
            return services;
        }

        public static IServiceCollection RegistratorContext(this IServiceCollection services)
        {
            services.AddDbContext<MyGameStoreContext>(options => options.UseSqlServer("name=ConnectionStrings:MyGameStore"));
            return services;
        }

        public static IServiceCollection RegistratorRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepositorie, PersonRepositorie>();
            services.AddScoped<IStoreRepositorie, StoreRepositorie>();

            return services;
        }

        public static IServiceCollection RegistratorUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
