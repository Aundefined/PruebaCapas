using Ejemplo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplo.Reporsitory.Data
{
    public class RepoDB: DbContext, IDisposable
    {
        public RepoDB(DbContextOptions<RepoDB> options):base(options)
        {

        }


        public DbSet<Centro> Centros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //modelbuilder.Entity<Centro>().ToTable("sp_Centro");

            //modelbuilder.Entity<Centro>().HasIndex(["Nombre" ]);

            modelbuilder.Entity<Centro>().HasKey(o => new { o.Nombre, o.IsAbierto });

            base.OnModelCreating(modelbuilder);
        }
    }
}
