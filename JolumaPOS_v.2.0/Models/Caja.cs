using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    [Table("Caja")]
    public partial class Caja
    {
        public Caja()
        {
            InventarioEntrada = new HashSet<InventarioEntradum>();
            InventarioSalida = new HashSet<InventarioSalidum>();
            Inventarios = new HashSet<Inventario>();
            Venta = new HashSet<Ventum>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Column("estatus")]
        public bool Estatus { get; set; }

        [InverseProperty(nameof(InventarioEntradum.CajaNavigation))]
        public virtual ICollection<InventarioEntradum> InventarioEntrada { get; set; }
        [InverseProperty(nameof(InventarioSalidum.CajaNavigation))]
        public virtual ICollection<InventarioSalidum> InventarioSalida { get; set; }
        [InverseProperty(nameof(Inventario.CajaNavigation))]
        public virtual ICollection<Inventario> Inventarios { get; set; }
        [InverseProperty(nameof(Ventum.CajaNavigation))]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
