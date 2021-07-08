using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    [Table("VentaDetalle")]
    public partial class VentaDetalle
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("venta")]
        public int Venta { get; set; }
        [Column("producto")]
        public int Producto { get; set; }
        [Column("cantProducto", TypeName = "decimal(18, 2)")]
        public decimal CantProducto { get; set; }
        [Column("precioVenta", TypeName = "money")]
        public decimal PrecioVenta { get; set; }
        [Column("tipoMonedaVenta")]
        public int TipoMonedaVenta { get; set; }
        [Column("precioCompra", TypeName = "money")]
        public decimal PrecioCompra { get; set; }
        [Column("tipoMonedaCompra")]
        public int TipoMonedaCompra { get; set; }

        [ForeignKey(nameof(Producto))]
        [InverseProperty("VentaDetalles")]
        public virtual Producto ProductoNavigation { get; set; }
        [ForeignKey(nameof(Venta))]
        [InverseProperty(nameof(Ventum.VentaDetalles))]
        public virtual Ventum VentaNavigation { get; set; }
    }
}
