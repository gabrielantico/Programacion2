using FacturaDLL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaDLL.Data
{
    public interface IAplicacion
    {
        bool Registrar(Factura factura);

        bool Actualizar(int id, Factura factura);

        List<Factura> Consultar(DateTime? fecha, int? idFormaPago);
    }
}
