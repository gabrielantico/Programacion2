using LibreriaDLL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDLL.Data
{
    public interface IAplicacion
    {
        List<Articulo> GetAll();

        Articulo GetById(int id);

        bool Insert(Articulo a);

        bool Update(Articulo a, int id);

        bool Delete(int id);
    }
}
