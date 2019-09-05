using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Models
{
    public class ViewFactura
    {
        public List<Producto> Producto { get; set; }
        public List<Factura> Factura { get; set; }
        public List<Detallefactura> DetalleFactura { get; set; }
    }
}
