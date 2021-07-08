using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("status")]
        public bool Status { get; set; }

        [InverseProperty(nameof(Ventum.ClienteNavigation))]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
