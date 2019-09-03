﻿// <auto-generated />
using System;
using Facturacion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Facturacion.Migrations
{
    [DbContext(typeof(FacturacionContext))]
    partial class FacturacionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Facturacion.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnName("Id_cliente");

                    b.Property<string>("Apellido")
                        .HasMaxLength(50);

                    b.Property<string>("Direccion")
                        .HasMaxLength(50);

                    b.Property<string>("Emeil")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.Property<int?>("Telefono");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Facturacion.Models.Detallefactura", b =>
                {
                    b.Property<int>("IdDetallefactura")
                        .HasColumnName("Id_detallefactura");

                    b.Property<string>("Apellido");

                    b.Property<decimal>("Cantidad")
                        .HasColumnName("cantidad")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("date");

                    b.Property<int>("IdFactura")
                        .HasColumnName("Id_Factura");

                    b.Property<decimal>("Iva")
                        .HasColumnName("IVA")
                        .HasMaxLength(10);

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnName("precio")
                        .HasColumnType("money");

                    b.Property<string>("Producto")
                        .HasColumnName("producto")
                        .HasMaxLength(50);

                    b.Property<decimal>("Total")
                        .HasColumnName("total");

                    b.HasKey("IdDetallefactura");

                    b.ToTable("Detallefactura");
                });

            modelBuilder.Entity("Facturacion.Models.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .HasColumnName("Id_factura");

                    b.Property<int?>("Cantidad")
                        .HasColumnName("cantidad");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("date");

                    b.Property<int?>("IdCliente")
                        .HasColumnName("Id_cliente");

                    b.Property<int?>("IdUsuario")
                        .HasColumnName("Id_usuario");

                    b.Property<decimal>("Iva")
                        .HasColumnName("IVA");

                    b.Property<decimal?>("Precio")
                        .HasColumnName("precio")
                        .HasColumnType("money");

                    b.Property<decimal>("Subtotal");

                    b.Property<decimal>("Total");

                    b.HasKey("IdFactura");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Facturacion.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .HasColumnName("Id_producto");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50);

                    b.Property<int?>("IdUsuario")
                        .HasColumnName("Id_usuario");

                    b.Property<string>("Nombreproducto")
                        .HasMaxLength(50);

                    b.Property<int?>("Precio");

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Facturacion.Models.Proveedor", b =>
                {
                    b.Property<string>("IdProveedor")
                        .HasColumnName("Id_proveedor")
                        .HasMaxLength(50);

                    b.Property<string>("Apellido")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.Property<string>("Producto")
                        .HasMaxLength(50);

                    b.Property<int?>("Telefono");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedor");
                });
#pragma warning restore 612, 618
        }
    }
}
