using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Table("Proveedor")]
    public partial class Proveedor
    {
        public Proveedor()
        {
            Contactos = new HashSet<Contacto>();
            InventarioEntrada = new HashSet<InventarioEntradum>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("razonSocial")]
        [StringLength(50)]
        public string RazonSocial { get; set; }
        [Required]
        [Column("RFC")]
        [StringLength(50)]
        public string Rfc { get; set; }
        [Required]
        [Column("calleDireccion")]
        public string CalleDireccion { get; set; }
        [Required]
        [Column("numDireccion")]
        public string NumDireccion { get; set; }
        [Required]
        [Column("colDireccion")]
        public string ColDireccion { get; set; }
        [Required]
        [Column("pais")]
        public string Pais { get; set; }
        [Required]
        [Column("estado")]
        public string Estado { get; set; }
        [Required]
        [Column("municipio")]
        public string Municipio { get; set; }
        [Column("status")]
        public bool Status { get; set; }

        [InverseProperty(nameof(Contacto.ProveedorNavigation))]
        public virtual ICollection<Contacto> Contactos { get; set; }
        [InverseProperty(nameof(InventarioEntradum.ProveedorNavigation))]
        public virtual ICollection<InventarioEntradum> InventarioEntrada { get; set; }
    }
}
