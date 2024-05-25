using ECommerce.Domain.Models;

namespace Ecommerce.Application.IServices
{
    public interface IProductoService
    {
        IEnumerable<Producto?> GetProductList();
        Producto? GetById(Guid id);
        bool CreateProduct(Producto producto);
        bool UpdateProduct(Producto producto);
        bool DeleteProduct(Guid id);
    }
}
