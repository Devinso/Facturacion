using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Nombreproducto { get; set; }
        public string Descripcion { get; set; }
        
        public int? Precio { get; set; }

        public int ProveedorId { get; set; }

        public Proveedor Proveedor { get; set; }

        public List<Detallefactura> Detallefactura { get; set; }
    }
}
