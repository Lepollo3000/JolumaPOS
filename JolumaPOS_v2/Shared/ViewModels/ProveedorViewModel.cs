using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolumaPOS_v2.Shared.ViewModels
{
    public class ProveedorViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string RazonSocial { get; set; }
        [StringLength(50)]
        public string Rfc { get; set; }
        public string CalleDireccion { get; set; }
        public string NumDireccion { get; set; }
        public string ColDireccion { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public bool Status { get; set; }
    }
}
