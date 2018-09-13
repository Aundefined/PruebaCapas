using Ejemplo.Model;
using Ejemplo.Reporsitory.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejemplo.Business
{
    public class CentroBS : ICentroBS
    {
        private RepoDB db = null;
        public CentroBS(RepoDB dbBAse)
        {
            this.db = dbBAse;
        }


        public List<Centro> GetList(string filterName="",int pageIndex=0, int pageSize=10)
        {
            IQueryable<Centro> result = this.db.Centros;

            if (!string.IsNullOrEmpty(filterName)) result = result.Where(o => o.Nombre == filterName);

            return result.OrderBy(o => o.Nombre).
                        Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public Centro Get(string nombre)
        {
            return this.db.Centros.SingleOrDefault(o => o.Nombre == nombre);
        }
        public void Insert(Centro centro, bool commit=true)
        {
            this.db.Centros.Add(centro);

            if (commit)db.SaveChanges();
        }

        public void Update(Centro centro, bool commit = true)
        {
            var c = Get(centro.Nombre);

            c.FechaInicio = centro.FechaInicio;

            if (commit) db.SaveChanges();
        }

        public void Delete(string nombre, bool commit = true)
        {
            var c = Get(nombre);

            this.db.Centros.Remove(c);

            if (commit) db.SaveChanges();
        }
    }
}
