using System.Collections.Generic;
using Ejemplo.Model;

namespace Ejemplo.Business
{
    public interface ICentroBS
    {
        void Delete(string nombre, bool commit = true);
        Centro Get(string nombre);
        List<Centro> GetList(string filterName = "", int pageIndex = 0, int pageSize = 10);
        void Insert(Centro centro, bool commit = true);
        void Update(Centro centro, bool commit = true);
    }
}