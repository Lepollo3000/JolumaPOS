using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Keyless]
    public partial class VProductoInventario
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("codigoBarras")]
        [StringLength(80)]
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
        [Required]
        [Column("nombreCategoria")]
        [StringLength(50)]
        public string NombreCategoria { get; set; }
        [Required]
        [Column("nombreUnidadMedida")]
        [StringLength(50)]
        public string NombreUnidadMedida { get; set; }
        [Column("caja")]
        public int Caja { get; set; }
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
    }
}
