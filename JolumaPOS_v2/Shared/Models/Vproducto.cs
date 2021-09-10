using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Keyless]
    public partial class Vproducto
    {
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
        [Required]
        [Column("nombreCategoria")]
        [StringLength(50)]
        public string NombreCategoria { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("unidadMedida")]
        public int UnidadMedida { get; set; }
        [Column("nombreUnidadMedida")]
        [StringLength(50)]
        public string NombreUnidadMedida { get; set; }
        [Column("requiereInventario")]
        public bool RequiereInventario { get; set; }
    }
}
