using System;
using JolumaPOS_v2.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JolumaPOS_v2.Server.Models
{
    public partial class JolumaPOSDevContext : DbContext
    {
        public JolumaPOSDevContext()
        {
        }

        public JolumaPOSDevContext(DbContextOptions<JolumaPOSDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caja> Cajas { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<ContactoTipo> ContactoTipos { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<InventarioEntradaDetalle> InventarioEntradaDetalles { get; set; }
        public virtual DbSet<InventarioEntradum> InventarioEntrada { get; set; }
        public virtual DbSet<InventarioSalidaDetalle> InventarioSalidaDetalles { get; set; }
        public virtual DbSet<InventarioSalidum> InventarioSalida { get; set; }
        public virtual DbSet<InventarioStatus> InventarioStatuses { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<TipoMonedum> TipoMoneda { get; set; }
        public virtual DbSet<TipoPago> TipoPagos { get; set; }
        public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }
        public virtual DbSet<VContactoProveedor> VContactoProveedors { get; set; }
        public virtual DbSet<VProductoInventario> VProductoInventarios { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }
        public virtual DbSet<VentaPago> VentaPagos { get; set; }
        public virtual DbSet<VentaStatus> VentaStatuses { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=JolumaPOSDev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasOne(d => d.PadreNavigation)
                    .WithMany(p => p.InversePadreNavigation)
                    .HasForeignKey(d => d.Padre)
                    .HasConstraintName("FK_Categoria_Categoria1");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.Proveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacto_ContactoProveedor");

                entity.HasOne(d => d.TipoContactoNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.TipoContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacto_ContactoTipo");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => new { e.Caja, e.Producto })
                    .HasName("PK_Inventario_1");

                entity.HasOne(d => d.CajaNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Caja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Caja");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Producto");

                entity.HasOne(d => d.TipoMonedaCompraNavigation)
                    .WithMany(p => p.InventarioTipoMonedaCompraNavigations)
                    .HasForeignKey(d => d.TipoMonedaCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_TipoMoneda");

                entity.HasOne(d => d.TipoMonedaVentaNavigation)
                    .WithMany(p => p.InventarioTipoMonedaVentaNavigations)
                    .HasForeignKey(d => d.TipoMonedaVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_TipoMoneda1");
            });

            modelBuilder.Entity<InventarioEntradaDetalle>(entity =>
            {
                entity.HasOne(d => d.EntradaInventarioNavigation)
                    .WithMany(p => p.InventarioEntradaDetalles)
                    .HasForeignKey(d => d.EntradaInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioEntradaDetalle_InventarioEntrada");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.InventarioEntradaDetalles)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioEntradaDetalle_Producto");
            });

            modelBuilder.Entity<InventarioEntradum>(entity =>
            {
                entity.HasOne(d => d.CajaNavigation)
                    .WithMany(p => p.InventarioEntrada)
                    .HasForeignKey(d => d.Caja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioEntrada_Caja");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.InventarioEntrada)
                    .HasForeignKey(d => d.Proveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioEntrada_ContactoProveedor");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.InventarioEntrada)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioEntrada_InventarioStatus");
            });

            modelBuilder.Entity<InventarioSalidaDetalle>(entity =>
            {
                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.InventarioSalidaDetalles)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioSalidaDetalle_Producto");

                entity.HasOne(d => d.SalidaInventarioNavigation)
                    .WithMany(p => p.InventarioSalidaDetalles)
                    .HasForeignKey(d => d.SalidaInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioSalidaDetalle_InventarioSalida");
            });

            modelBuilder.Entity<InventarioSalidum>(entity =>
            {
                entity.HasOne(d => d.CajaNavigation)
                    .WithMany(p => p.InventarioSalida)
                    .HasForeignKey(d => d.Caja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioSalida_Caja");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.InventarioSalida)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventarioSalida_InventarioStatus");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasOne(d => d.CategoriaNavigation)
                    .WithOne(p => p.Producto)
                    .HasForeignKey<Producto>(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Categoria1");

                entity.HasOne(d => d.UnidadMedidaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.UnidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_UnidadMedida");
            });

            modelBuilder.Entity<VContactoProveedor>(entity =>
            {
                entity.ToView("vContactoProveedor");
            });

            modelBuilder.Entity<VProductoInventario>(entity =>
            {
                entity.ToView("vProductoInventario");
            });

            modelBuilder.Entity<VentaDetalle>(entity =>
            {
                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.VentaDetalles)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentaDetalle_Producto");

                entity.HasOne(d => d.VentaNavigation)
                    .WithMany(p => p.VentaDetalles)
                    .HasForeignKey(d => d.Venta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentaDetalle_Venta");
            });

            modelBuilder.Entity<VentaPago>(entity =>
            {
                entity.HasOne(d => d.TipoPagoNavigation)
                    .WithMany(p => p.VentaPagos)
                    .HasForeignKey(d => d.TipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentaPago_TipoPago");

                entity.HasOne(d => d.VentaNavigation)
                    .WithMany(p => p.VentaPagos)
                    .HasForeignKey(d => d.Venta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentaPago_Venta");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasOne(d => d.CajaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Caja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Caja");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Cliente");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_VentaStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
