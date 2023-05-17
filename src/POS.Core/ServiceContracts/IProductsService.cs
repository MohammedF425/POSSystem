using System;
using POS.Core.DTOs;
namespace POS.Core.ServiceContracts
{
    public interface IProductsService
    {
        Task<ProductResponse?> AddProduct(ProductAddRequest? productAddRequest);
        Task<List<ProductResponse>> GetAllProducts();
        Task<ProductResponse?> GetProductByProductID(int id);
        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest? product);
        Task<bool> DeleteProductByProductID(int id);
    }
}



