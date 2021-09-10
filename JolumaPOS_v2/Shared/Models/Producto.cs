using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            InventarioEntradaDetalles = new HashSet<InventarioEntradaDetalle>();
            InventarioSalidaDetalles = new HashSet<InventarioSalidaDetalle>();
            Inventarios = new HashSet<Inventario>();
            VentaDetalles = new HashSet<VentaDetalle>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("codigoBarras")]
        [StringLength(50)]
        public string CodigoBarras { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("descripcionProducto")]
        public string DescripcionProducto { get; set; }
        [Column("categoria")]
        public int Categoria { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("unidadMedida")]
        public int UnidadMedida { get; set; }
        [Column("requiereInventario")]
        public bool RequiereInventario { get; set; }

        [ForeignKey(nameof(Categoria))]
        [InverseProperty(nameof(Categorium.Productos))]
        public virtual Categorium CategoriaNavigation { get; set; }
        [ForeignKey(nameof(UnidadMedida))]
        [InverseProperty(nameof(UnidadMedidum.Productos))]
        public virtual UnidadMedidum UnidadMedidaNavigation { get; set; }
        [InverseProperty(nameof(InventarioEntradaDetalle.ProductoNavigation))]
        public virtual ICollection<InventarioEntradaDetalle> InventarioEntradaDetalles { get; set; }
        [InverseProperty(nameof(InventarioSalidaDetalle.ProductoNavigation))]
        public virtual ICollection<InventarioSalidaDetalle> InventarioSalidaDetalles { get; set; }
        [InverseProperty(nameof(Inventario.ProductoNavigation))]
        public virtual ICollection<Inventario> Inventarios { get; set; }
        [InverseProperty(nameof(VentaDetalle.ProductoNavigation))]
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
