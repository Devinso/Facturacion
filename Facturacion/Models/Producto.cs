using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Nombreproducto { get; set; }
        public string Descripcion { get; set; }
        public int? IdFactura { get; set; }
        public int? IdUsuario { get; set; }
        public int? Precio { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
