using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    [Table("TipoPago")]
    public partial class TipoPago
    {
        public TipoPago()
        {
            VentaPagos = new HashSet<VentaPago>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(VentaPago.TipoPagoNavigation))]
        public virtual ICollection<VentaPago> VentaPagos { get; set; }
    }
}
