using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Keyless]
    public partial class VventaDetalleProducto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("venta")]
        public int Venta { get; set; }
        [Column("producto")]
        public int Producto { get; set; }
        [Required]
        [Column("nombreProducto")]
        [StringLength(50)]
        public string NombreProducto { get; set; }
        [Column("cantProducto", TypeName = "decimal(18, 2)")]
        public decimal CantProducto { get; set; }
        [Column("precioVenta", TypeName = "money")]
        public decimal PrecioVenta { get; set; }
        [Column("tipoMonedaVenta")]
        public int TipoMonedaVenta { get; set; }
        [Column("nombreTipoMonedaVenta")]
        public string NombreTipoMonedaVenta { get; set; }
        [Column("precioCompra", TypeName = "money")]
        public decimal PrecioCompra { get; set; }
        [Column("tipoMonedaCompra")]
        public int TipoMonedaCompra { get; set; }
        [Column("nombreTipoMonedaCompra")]
        public string NombreTipoMonedaCompra { get; set; }
    }
}
