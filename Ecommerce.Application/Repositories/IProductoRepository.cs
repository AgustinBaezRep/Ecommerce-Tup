using ECommerce.Domain.Models;

namespace Ecommerce.Application.Repositories
{
    public interface IProductoRepository
    {
        IEnumerable<Producto?> GetProductList();
        Producto? GetById(Guid id);
        bool CreateProduct(Producto producto);
        bool UpdateProduct(Producto producto);
        bool DeleteProduct(Guid id);
    }
}
