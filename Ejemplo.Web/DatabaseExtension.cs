using Ejemplo.Reporsitory.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplo.Business
{
    public static class DatabaseExtension
    {
        /// <returns></returns>
        public static IApplicationBuilder CreateNavDb(this IApplicationBuilder app)
        {
            return CreateNavDb(app, out CreateDbResult res);
        }
        /// <summary>
        /// Crea la base de datos con la estructura de sus modelos si no existe.
        /// Si una tabla ya existe, no se crearán las demás.
        /// </summary>
        /// <param name="result">Contiene booleanas para obtener resultados de las distitnas etapas de la creación de la BD.</param>
        /// <returns></returns>
        public static IApplicationBuilder CreateNavDb(this IApplicationBuilder app, out CreateDbResult result)
        {
            result = new CreateDbResult();

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RepoDB>();
                var databaseCreator = (Microsoft.EntityFrameworkCore.Storage.RelationalDatabaseCreator)
                        context.Database.GetService<Microsoft.EntityFrameworkCore.Storage.IDatabaseCreator>();

                try
                {
                    result.DatabaseExists = databaseCreator.Exists();
                    if (result.DatabaseExists)
                    {
                        databaseCreator.CreateTables(); //Will throw exception if already created.
                        result.TablesWhereCreated = true;
                    }
                    else
                    {
                        result.DatabaseWasCreated = databaseCreator.EnsureCreated();
                        result.TablesWhereCreated = result.DatabaseWasCreated;
                    }
                }
                catch (System.Exception ex) { }

                return app;
            }
        }
    }

    public class CreateDbResult
    {
        public bool DatabaseExists { get; internal set; }
        public bool DatabaseWasCreated { get; internal set; }
        public bool TablesWhereCreated { get; internal set; }
    }
}