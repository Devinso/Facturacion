using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Facturacion.Models
{
    public partial class FacturacionContext : DbContext
    {
        public FacturacionContext()
        {
        }

        public FacturacionContext(DbContextOptions<FacturacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Detallefactura> Detallefactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-V6Q5059;Database=Facturacion;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente)
                    .HasColumnName("Id_cliente")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Emeil).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Detallefactura>(entity =>
            {
                entity.HasKey(e => e.IdDetallefactura);

                entity.Property(e => e.IdDetallefactura)
                    .HasColumnName("Id_detallefactura")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasMaxLength(10);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");

                entity.Property(e => e.Iva)
                    .HasColumnName("IVA")
                    .HasMaxLength(10);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("money");

                entity.Property(e => e.Producto)
                    .HasColumnName("producto")
                    .HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.Property(e => e.IdFactura)
                    .HasColumnName("Id_factura")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("money");


            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_producto")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(50);



                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.Property(e => e.Nombreproducto).HasMaxLength(50);


            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("Id_proveedor")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Producto).HasMaxLength(50);
            });



        }
    }
}