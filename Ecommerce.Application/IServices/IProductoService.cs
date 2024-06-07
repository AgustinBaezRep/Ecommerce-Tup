﻿using ECommerce.Domain.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.ViewModels;

namespace Ecommerce.Application.IServices
{
    public interface IProductoService
    {
        IEnumerable<ProductoDTO?> GetProductList();
        ProductoDTO? GetById(Guid id);
        bool CreateProduct(CreateProductoViewModel producto);
        bool UpdateProduct(CreateProductoViewModel producto);
        bool DeleteProduct(Guid id);
        IEnumerable<ProductoConComponentesDTO> GetCombination();
    }
}
