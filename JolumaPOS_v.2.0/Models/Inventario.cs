using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    [Table("Inventario")]
    public partial class Inventario
    {
        [Key]
        [Column("caja")]
        public int Caja { get; set; }
        [Key]
        [Column("producto")]
        public int Producto { get; set; }
        [Column("precioCompra", TypeName = "money")]
        public decimal PrecioCompra { get; set; }
        [Column("precioVenta", TypeName = "money")]
        public decimal PrecioVenta { get; set; }
        [Column("tipoMonedaCompra")]
        public int TipoMonedaCompra { get; set; }
        [Column("tipoMonedaVenta")]
        public int TipoMonedaVenta { get; set; }
        [Column("puntoReorden")]
        public int? PuntoReorden { get; set; }
        [Column("cantidadStock")]
        public int? CantidadStock { get; set; }

        [ForeignKey(nameof(Caja))]
        [InverseProperty("Inventarios")]
        public virtual Caja CajaNavigation { get; set; }
        [ForeignKey(nameof(Producto))]
        [InverseProperty("Inventarios")]
        public virtual Producto ProductoNavigation { get; set; }
        [ForeignKey(nameof(TipoMonedaCompra))]
        [InverseProperty(nameof(TipoMonedum.InventarioTipoMonedaCompraNavigations))]
        public virtual TipoMonedum TipoMonedaCompraNavigation { get; set; }
        [ForeignKey(nameof(TipoMonedaVenta))]
        [InverseProperty(nameof(TipoMonedum.InventarioTipoMonedaVentaNavigations))]
        public virtual TipoMonedum TipoMonedaVentaNavigation { get; set; }
    }
}
