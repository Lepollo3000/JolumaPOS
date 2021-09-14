using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolumaPOS_v2.Shared.ViewModels
{
    public class ContactoViewModel
    {
        [Key]
        public int Id { get; set; }
        public int Proveedor { get; set; }
        public int TipoContacto { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        public bool Status { get; set; }
    }
}
