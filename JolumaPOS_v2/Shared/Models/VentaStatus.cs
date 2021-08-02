using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Table("VentaStatus")]
    public partial class VentaStatus
    {
        public VentaStatus()
        {
            Venta = new HashSet<Ventum>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Ventum.StatusNavigation))]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
