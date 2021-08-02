using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Table("InventarioSalidaDetalle")]
    public partial class InventarioSalidaDetalle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("salidaInventario")]
        public int SalidaInventario { get; set; }
        [Column("producto")]
        public int Producto { get; set; }
        [Column("razon")]
        public int Razon { get; set; }
        [Column("cantidadProducto", TypeName = "decimal(18, 2)")]
        public decimal CantidadProducto { get; set; }

        [ForeignKey(nameof(Producto))]
        [InverseProperty("InventarioSalidaDetalles")]
        public virtual Producto ProductoNavigation { get; set; }
        [ForeignKey(nameof(SalidaInventario))]
        [InverseProperty(nameof(InventarioSalidum.InventarioSalidaDetalles))]
        public virtual InventarioSalidum SalidaInventarioNavigation { get; set; }
    }
}
