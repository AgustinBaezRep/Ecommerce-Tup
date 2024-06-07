using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.DTOs
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public int? Stock { get; set; }
        public bool Activo { get; set; }
    }
}
