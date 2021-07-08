using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            VentaDetalles = new HashSet<VentaDetalle>();
            VentaPagos = new HashSet<VentaPago>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("cliente")]
        public int Cliente { get; set; }
        [Required]
        [Column("empleado")]
        [StringLength(450)]
        public string Empleado { get; set; }
        [Column("caja")]
        public int Caja { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(Caja))]
        [InverseProperty("Venta")]
        public virtual Caja CajaNavigation { get; set; }
        [ForeignKey(nameof(Cliente))]
        [InverseProperty("Venta")]
        public virtual Cliente ClienteNavigation { get; set; }
        [ForeignKey(nameof(Status))]
        [InverseProperty(nameof(VentaStatus.Venta))]
        public virtual VentaStatus StatusNavigation { get; set; }
        [InverseProperty(nameof(VentaDetalle.VentaNavigation))]
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
        [InverseProperty(nameof(VentaPago.VentaNavigation))]
        public virtual ICollection<VentaPago> VentaPagos { get; set; }
    }
}
