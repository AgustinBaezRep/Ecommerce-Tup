using Ecommerce.Application.IServices;
using Ecommerce.Application.Repositories;
using ECommerce.Domain.Models;

namespace Ecommerce.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Producto?> GetProductList()
        {
            return _repository.GetProductList();
        }

        public Producto? GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool CreateProduct(Producto producto)
        {
            if (_repository.GetById(producto.Id) != null)
            {
                return false;
            }

            return _repository.CreateProduct(producto);
        }

        public bool UpdateProduct(Producto producto)
        {
            return _repository.UpdateProduct(producto);
        }

        public bool DeleteProduct(Guid id)
        {
            return _repository.DeleteProduct(id);
        }
    }
}
