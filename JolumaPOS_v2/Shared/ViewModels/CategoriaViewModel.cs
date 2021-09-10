using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolumaPOS_v2.Shared.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? Padre { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public bool Status { get; set; }
    }
}
