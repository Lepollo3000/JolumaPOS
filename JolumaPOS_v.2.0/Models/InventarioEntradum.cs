using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    public partial class InventarioEntradum
    {
        public InventarioEntradum()
        {
            InventarioEntradaDetalles = new HashSet<InventarioEntradaDetalle>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("proveedor")]
        public int Proveedor { get; set; }
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
        [InverseProperty("InventarioEntrada")]
        public virtual Caja CajaNavigation { get; set; }
        [ForeignKey(nameof(Proveedor))]
        [InverseProperty("InventarioEntrada")]
        public virtual Proveedor ProveedorNavigation { get; set; }
        [ForeignKey(nameof(Status))]
        [InverseProperty(nameof(InventarioStatus.InventarioEntrada))]
        public virtual InventarioStatus StatusNavigation { get; set; }
        [InverseProperty(nameof(InventarioEntradaDetalle.EntradaInventarioNavigation))]
        public virtual ICollection<InventarioEntradaDetalle> InventarioEntradaDetalles { get; set; }
    }
}
