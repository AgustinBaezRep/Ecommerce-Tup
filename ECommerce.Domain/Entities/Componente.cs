using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Componente
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public Producto Producto { get; set; }
        public Componente()
        {

        }
    }
}
