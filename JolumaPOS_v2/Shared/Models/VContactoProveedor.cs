using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Keyless]
    public partial class VContactoProveedor
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("proveedor")]
        public int Proveedor { get; set; }
        [Column("tipoContacto")]
        public int TipoContacto { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [Column("email")]
        [StringLength(500)]
        public string Email { get; set; }
        [Required]
        [Column("telefono")]
        [StringLength(50)]
        public string Telefono { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [Column("razonSocial")]
        [StringLength(50)]
        public string RazonSocial { get; set; }
        [Required]
        [Column("RFC")]
        [StringLength(50)]
        public string Rfc { get; set; }
    }
}
