using Ecommerce.Application.IRepositories;
using ECommerce.Domain.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.ViewModels;
using ECommerce.Infraestructure.Context;
using System.ComponentModel;

namespace ECommerce.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductoRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductoConComponentesDTO> GetCombination()
        {
            return _context.Productos
                    .Join(
                        _context.Componentes,
                        p => p.Id,
                        c => c.Producto.Id,
                        (p, c) => new { Producto = p, Componente = c }
                    )
                    .GroupBy(
                        pc => new { pc.Producto.Id, pc.Producto.Descripcion, pc.Producto.PrecioUnitario },
                        pc => pc.Componente,
                        (key, componentes) => new ProductoConComponentesDTO
                        {
                            DescripcionProducto = key.Descripcion,
                            PrecioProducto = key.PrecioUnitario,
                            Componentes = componentes.Select(c => new ComponenteDTO
                            {
                                DescripcionComponente = c.Descripcion,
                                PrecioComponente = c.Precio
                            }).ToList()
                        }
                    )
                    .ToList();
        }

        public IEnumerable<ProductoDTO?> GetProductList()
        {
            return _context.Productos
                .Where(p => p.Activo)
                .Select(p => new ProductoDTO
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    PrecioUnitario = p.PrecioUnitario,
                    Stock = p.Stock,
                    Activo = p.Activo
                })
                .ToList();
        }

        public ProductoDTO? GetById(Guid id)
        {
            return _context.Productos
                .Where(x => x.Id == id && x.Activo)
                .Select(p => new ProductoDTO
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    PrecioUnitario = p.PrecioUnitario,
                    Stock = p.Stock,
                    Activo = p.Activo
                })
                .FirstOrDefault();
        }

        public bool CreateProduct(CreateProductoViewModel producto)
        {
            producto.Id = Guid.NewGuid();
            var prod = _context.Productos.FirstOrDefault(p => p.Id == producto.Id);

            if (prod != null)
            {
                return false;
            }

            _context.Productos.Add(new Producto
            {
                Id = producto.Id,
                Activo = true,
                Descripcion = producto.Descripcion,
                PrecioUnitario = producto.PrecioUnitario,
                Stock = producto.Stock
            });
            _context.SaveChanges();
            return true;
        }

        public bool UpdateProduct(CreateProductoViewModel producto)
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
