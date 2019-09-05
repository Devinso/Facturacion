using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Telefono { get; set; }
        public List<Producto> Producto { get; set; }
    }
}
