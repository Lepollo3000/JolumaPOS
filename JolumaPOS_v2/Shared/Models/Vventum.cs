using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v2.Shared.Models
{
    [Keyless]
    public partial class Vventum
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("cliente")]
        public int Cliente { get; set; }
        [Required]
        [Column("empleado")]
        [StringLength(450)]
        public string Empleado { get; set; }
        [Required]
        [Column("nombreEmpleado")]
        public string NombreEmpleado { get; set; }
        [Column("caja")]
        public int Caja { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
