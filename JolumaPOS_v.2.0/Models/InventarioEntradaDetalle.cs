using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    [Table("InventarioEntradaDetalle")]
    public partial class InventarioEntradaDetalle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("entradaInventario")]
        public int EntradaInventario { get; set; }
        [Column("producto")]
        public int Producto { get; set; }
        [Column("razon")]
        public int Razon { get; set; }
        [Column("cantidadProducto", TypeName = "decimal(18, 2)")]
        public decimal CantidadProducto { get; set; }
        [Column("precioCompra", TypeName = "money")]
        public decimal PrecioCompra { get; set; }

        [ForeignKey(nameof(EntradaInventario))]
        [InverseProperty(nameof(InventarioEntradum.InventarioEntradaDetalles))]
        public virtual InventarioEntradum EntradaInventarioNavigation { get; set; }
        [ForeignKey(nameof(Producto))]
        [InverseProperty("InventarioEntradaDetalles")]
        public virtual Producto ProductoNavigation { get; set; }
    }
}
