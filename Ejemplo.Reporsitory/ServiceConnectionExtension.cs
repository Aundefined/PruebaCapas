using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo.Reporsitory
{
    public static class ServiceConnectionExtension
    {

        public static IServiceCollection AddDBContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Reporsitory.Data.RepoDB>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
