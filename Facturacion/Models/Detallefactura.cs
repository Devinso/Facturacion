using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Detallefactura
    {
        public int DetalleFacturaId { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total { get; set; }
        public decimal Iva { get; set; }
        public DateTime Fecha { get; set; }
        public int IdFactura { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
    }
}
