using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    [Table("ContactoTipo")]
    public partial class ContactoTipo
    {
        public ContactoTipo()
        {
            Contactos = new HashSet<Contacto>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Contacto.TipoContactoNavigation))]
        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
