using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ejemplo.Reporsitory;

namespace Ejemplo.Business
{
    public static class BussinessExtension
    {

        public static IServiceCollection AddBusinessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDBContext(connectionString);

            return services.AddServiceInfo();
        }

        public static IServiceCollection AddServiceInfo(this IServiceCollection services)
        {
            // services.AddSingleton<ICentroBS, CentroBS>();
            services.AddScoped<ICentroBS, CentroBS>();

            return services;
        }
    }
}
