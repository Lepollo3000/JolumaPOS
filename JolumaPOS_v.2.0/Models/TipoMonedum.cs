using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JolumaPOS_v._2._0.Models
{
    public partial class TipoMonedum
    {
        public TipoMonedum()
        {
            InventarioTipoMonedaCompraNavigations = new HashSet<Inventario>();
            InventarioTipoMonedaVentaNavigations = new HashSet<Inventario>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Inventario.TipoMonedaCompraNavigation))]
        public virtual ICollection<Inventario> InventarioTipoMonedaCompraNavigations { get; set; }
        [InverseProperty(nameof(Inventario.TipoMonedaVentaNavigation))]
        public virtual ICollection<Inventario> InventarioTipoMonedaVentaNavigations { get; set; }
    }
}
