using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyGameStore.Data.Context;
using MyGameStore.Data.Repositories;
using MyGameStore.DLL.Interfaces;
using MyGameStore.DLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.DLL.Extensions
{
    public static class DLLExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IStoreService, StoreService>();

            return services;
        }
    }

}
