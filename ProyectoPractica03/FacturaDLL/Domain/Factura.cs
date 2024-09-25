using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaDLL.Domain
{
    public class Factura
    {
        public int NroFactura { get; set; }

        public DateTime Fecha { get; set; }

        public FormaPago Forma { get; set; }

        public string Cliente { get; set; }

        public List<DetalleFactura> Detalles { get; set; }

        public Factura()
        {
            Forma = new FormaPago();
        }
    }
}
