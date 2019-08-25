﻿using System;
using System.Collections.Generic;

namespace Facturacion.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Precio { get; set; }
        public string Producto { get; set; }
        public int? IdUsuario { get; set; }
        public int? Cantidad { get; set; }
        public int? Total { get; set; }
        public int? Iva { get; set; }
        public int? IdCliente { get; set; }
    }
}