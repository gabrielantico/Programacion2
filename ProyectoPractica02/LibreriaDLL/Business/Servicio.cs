using LibreriaDLL.Data;
using LibreriaDLL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDLL.Business
{
    public class Servicio
    {
        private ArticuloRepository repository;

        public Servicio()
        {
            repository = new ArticuloRepository();
        }

        public List<Articulo> GetAll()
        {
            return repository.GetAll();
        }

        public Articulo GetById(int id)
        {
            return repository.GetById(id);
        }
        
        public bool Insert(Articulo a)
        {
            return repository.Insert(a);
        }

        public bool Update(Articulo a, int id)
        {
            return repository.Update(a, id);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
