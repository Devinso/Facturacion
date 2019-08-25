using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Emeil { get; set; }
        public int? Telefono { get; set; }
    }
}
