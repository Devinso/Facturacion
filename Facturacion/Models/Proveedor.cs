using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Usuario = new HashSet<Usuario>();
        }

        public string IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Producto { get; set; }
        public int? Telefono { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
