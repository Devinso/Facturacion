﻿// <auto-generated />
using System;
using Facturacion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Facturacion.Migrations
{
    [DbContext(typeof(FacturacionContext))]
    [Migration("20190825173538_IdentityCreateSchema")]
    partial class IdentityCreateSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Cantidad")
                        .HasColumnName("cantidad")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("date");

                    b.Property<int?>("IdFactura")
                        .HasColumnName("Id_Factura");

                    b.Property<string>("Iva")
                        .HasColumnName("IVA")
                        .HasMaxLength(10);

                    b.Property<decimal?>("Precio")
                        .HasColumnName("precio")
                        .HasColumnType("money");

                    b.Property<string>("Producto")
                        .HasColumnName("producto")
                        .HasMaxLength(50);

                    b.Property<int?>("Total")
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

                    b.Property<int?>("Iva")
                        .HasColumnName("IVA");

                    b.Property<decimal?>("Precio")
                        .HasColumnName("precio")
                        .HasColumnType("money");

                    b.Property<string>("Producto")
                        .HasColumnName("producto")
                        .HasMaxLength(50);

                    b.Property<int?>("Total");

                    b.HasKey("IdFactura");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Facturacion.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .HasColumnName("Id_producto");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50);

                    b.Property<int?>("IdFactura")
                        .HasColumnName("Id_Factura");

                    b.Property<int?>("IdUsuario")
                        .HasColumnName("Id_usuario");

                    b.Property<string>("Nombreproducto")
                        .HasMaxLength(50);

                    b.Property<int?>("Precio");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdUsuario");

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

            modelBuilder.Entity("Facturacion.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnName("Id_usuario");

                    b.Property<string>("Apellido")
                        .HasMaxLength(50);

                    b.Property<string>("IdProveedor")
                        .HasColumnName("Id_proveedor")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50);

                    b.Property<int?>("Telefono");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Facturacion.Models.Producto", b =>
                {
                    b.HasOne("Facturacion.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Producto")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Producto_Usuario");
                });

            modelBuilder.Entity("Facturacion.Models.Usuario", b =>
                {
                    b.HasOne("Facturacion.Models.Proveedor", "IdProveedorNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("IdProveedor")
                        .HasConstraintName("FK_Usuario_Proveedor");
                });
#pragma warning restore 612, 618
        }
    }
}
