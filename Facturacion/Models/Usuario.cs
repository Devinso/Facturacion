using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Telefono { get; set; }
        public string IdProveedor { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
