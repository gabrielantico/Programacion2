using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaDLL.Domain
{
    public class DetalleFactura
    {

        public int NroDetalle { get; set; }

        public Articulo Articulo { get; set; }

        public decimal Cantidad { get; set; }
    }
}
