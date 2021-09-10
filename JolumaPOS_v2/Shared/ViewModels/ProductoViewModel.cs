using JolumaPOS_v2.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolumaPOS_v2.Shared.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public string DescripcionProducto { get; set; }
        public int Categoria { get; set; }
        public bool Status { get; set; }
        public int UnidadMedida { get; set; }
        public bool RequiereInventario { get; set; }
    }
}
