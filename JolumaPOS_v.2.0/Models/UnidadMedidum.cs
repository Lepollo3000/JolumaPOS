using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    public partial class UnidadMedidum
    {
        public UnidadMedidum()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Producto.UnidadMedidaNavigation))]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
