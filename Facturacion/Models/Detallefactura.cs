using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Detallefactura
    {
        public int IdDetallefactura { get; set; }
        public string Producto { get; set; }
        public decimal? Precio { get; set; }
        public string Cantidad { get; set; }
        public int? Total { get; set; }
        public string Iva { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdFactura { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
