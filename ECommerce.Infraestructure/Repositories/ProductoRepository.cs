using Ecommerce.Application.Repositories;
using ECommerce.Domain.Models;
using ECommerce.Infraestructure.Context;

namespace ECommerce.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductoRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto?> GetProductList()
        {
            return _context.Productos.Where(p => p.Activo).ToList();
        }

        public Producto? GetById(Guid id)
        {
            return _context.Productos.FirstOrDefault(x => x.Id == id && x.Activo);
        }

        public bool CreateProduct(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Producto producto)
        {
            var prod = _context.Productos.FirstOrDefault(x => x.Id == producto.Id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Descripcion = producto.Descripcion;
            prod.Stock = producto.Stock;
            prod.PrecioUnitario = producto.PrecioUnitario;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(Guid id)
        {
            var prod = _context.Productos.FirstOrDefault(x => x.Id == id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Activo = false;
            _context.SaveChanges();
            return true;
        }
    }
}
