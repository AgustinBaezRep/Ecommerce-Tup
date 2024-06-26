﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Entities
{
    public class Producto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }
        public int? Stock { get; set; }
        public bool Activo { get; set; }
        public ICollection<Componente> Componentes { get; set; }

        public Producto()
        {

        }
    }
}
