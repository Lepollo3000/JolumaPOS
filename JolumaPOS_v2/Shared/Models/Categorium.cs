using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            InversePadreNavigation = new HashSet<Categorium>();
            Productos = new HashSet<Producto>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("padre")]
        public int? Padre { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Column("status")]
        public bool Status { get; set; }

        [ForeignKey(nameof(Padre))]
        [InverseProperty(nameof(Categorium.InversePadreNavigation))]
        public virtual Categorium PadreNavigation { get; set; }
        [InverseProperty(nameof(Categorium.PadreNavigation))]
        public virtual ICollection<Categorium> InversePadreNavigation { get; set; }
        [InverseProperty(nameof(Producto.CategoriaNavigation))]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
