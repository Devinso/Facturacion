using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Migrations
{
    public partial class Cambiostiposdatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(maxLength: 50, nullable: true),
                    Emeil = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Detallefactura",
                columns: table => new
                {
                    Id_detallefactura = table.Column<int>(nullable: false),
                    producto = table.Column<string>(maxLength: 50, nullable: true),
                    precio = table.Column<decimal>(type: "money", nullable: false),
                    cantidad = table.Column<decimal>(maxLength: 10, nullable: false),
                    total = table.Column<decimal>(nullable: false),
                    IVA = table.Column<decimal>(maxLength: 10, nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    Id_Factura = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detallefactura", x => x.Id_detallefactura);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id_factura = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    precio = table.Column<decimal>(type: "money", nullable: true),
                    Id_usuario = table.Column<int>(nullable: true),
                    cantidad = table.Column<int>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    IVA = table.Column<decimal>(nullable: false),
                    Id_cliente = table.Column<int>(nullable: true),
                    Subtotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id_factura);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id_producto = table.Column<int>(nullable: false),
                    Nombreproducto = table.Column<string>(maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    Id_usuario = table.Column<int>(nullable: true),
                    Precio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id_producto);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id_proveedor = table.Column<string>(maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(maxLength: 50, nullable: true),
                    Producto = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id_proveedor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Detallefactura");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
