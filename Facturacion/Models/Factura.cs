using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Factura
    {
        public static object Approve { get; internal set; }
        public int IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Precio { get; set; }

        public int? IdUsuario { get; set; }
        public int? Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public int? IdCliente { get; set; }

    }
}
