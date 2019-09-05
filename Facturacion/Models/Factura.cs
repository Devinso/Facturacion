using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Factura
    {
        public int FacturaId { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public List<Detallefactura> Detallefactura { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
