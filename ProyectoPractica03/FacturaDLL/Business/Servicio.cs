using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturaDLL.Data;
using FacturaDLL.Domain;

namespace FacturaDLL.Business
{
    public class Servicio
    {
        private RepositoryFactura repository;
        public Servicio()
        {
            repository = new RepositoryFactura();
        }

        public bool Actualizar(int id, Factura factura)
        {
            return repository.Actualizar(id, factura);
        }

        public bool Registrar(Factura factura)
        {
            return repository.Registrar(factura);
        }

        public List<Factura> Consultar(DateTime? fecha, int? idFormaPago)
        {
            return repository.Consultar(fecha, idFormaPago);
        }
    }
}
