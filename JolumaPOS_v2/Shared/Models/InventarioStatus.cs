using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Table("InventarioStatus")]
    public partial class InventarioStatus
    {
        public InventarioStatus()
        {
            InventarioEntrada = new HashSet<InventarioEntradum>();
            InventarioSalida = new HashSet<InventarioSalidum>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(InventarioEntradum.StatusNavigation))]
        public virtual ICollection<InventarioEntradum> InventarioEntrada { get; set; }
        [InverseProperty(nameof(InventarioSalidum.StatusNavigation))]
        public virtual ICollection<InventarioSalidum> InventarioSalida { get; set; }
    }
}
