using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.DTOs
{
    public class ProductoConComponentesDTO
    {
        public string DescripcionProducto { get; set; }
        public double PrecioProducto { get; set; }
        public List<ComponenteDTO> Componentes { get; set; }
    }
}
