using Ecommerce.Application.IRepositories;
using Ecommerce.Application.IServices;
using ECommerce.Domain.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.ViewModels;

namespace Ecommerce.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProductoDTO?> GetProductList()
        {
            return _repository.GetProductList();
        }

        public ProductoDTO? GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool CreateProduct(CreateProductoViewModel producto)
        {
            return _repository.CreateProduct(producto);
        }

        public bool UpdateProduct(CreateProductoViewModel producto)
        {
            return _repository.UpdateProduct(producto);
        }

        public bool DeleteProduct(Guid id)
        {
            return _repository.DeleteProduct(id);
        }

        public IEnumerable<ProductoConComponentesDTO> GetCombination()
        {
            return _repository.GetCombination();
        }
    }
}
