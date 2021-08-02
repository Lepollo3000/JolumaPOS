using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Table("VentaPago")]
    public partial class VentaPago
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("venta")]
        public int Venta { get; set; }
        [Column("tipoPago")]
        public int TipoPago { get; set; }
        [Column("montoPagado", TypeName = "money")]
        public decimal MontoPagado { get; set; }
        [Column("montoTotal", TypeName = "money")]
        public decimal MontoTotal { get; set; }

        [ForeignKey(nameof(TipoPago))]
        [InverseProperty("VentaPagos")]
        public virtual TipoPago TipoPagoNavigation { get; set; }
        [ForeignKey(nameof(Venta))]
        [InverseProperty(nameof(Ventum.VentaPagos))]
        public virtual Ventum VentaNavigation { get; set; }
    }
}
