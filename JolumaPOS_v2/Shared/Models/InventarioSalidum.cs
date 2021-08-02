using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    public partial class InventarioSalidum
    {
        public InventarioSalidum()
        {
            InventarioSalidaDetalles = new HashSet<InventarioSalidaDetalle>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("caja")]
        public int Caja { get; set; }
        [Required]
        [Column("empleado")]
        [StringLength(450)]
        public string Empleado { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(Caja))]
        [InverseProperty("InventarioSalida")]
        public virtual Caja CajaNavigation { get; set; }
        [ForeignKey(nameof(Status))]
        [InverseProperty(nameof(InventarioStatus.InventarioSalida))]
        public virtual InventarioStatus StatusNavigation { get; set; }
        [InverseProperty(nameof(InventarioSalidaDetalle.SalidaInventarioNavigation))]
        public virtual ICollection<InventarioSalidaDetalle> InventarioSalidaDetalles { get; set; }
    }
}
