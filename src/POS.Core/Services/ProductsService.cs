using System;
using POS.Core.Domain.Entities;
using POS.Core.Domain.RepositoryContracts;
using POS.Core.DTOs;
using POS.Core.ServiceContracts;

namespace POS.Core.Services
{
    public class ProductsService : IProductsService
    {
        public readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<ProductResponse?> AddProduct(ProductAddRequest? productAddRequest)
        {
            if (productAddRequest == null || productAddRequest.ProductDescription == null) return null;

            Product product = productAddRequest.ToProduct();
           
            product = await _productsRepository.AddProduct(product);


            return product.ToProductResponse();
        }

        public async Task<bool> DeleteProductByProductID(int id)
        {
            return await _productsRepository.DeleteProductByProductID(id);
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            List<Product> products = await _productsRepository.GetAllProducts();
            return products.Select(p => p.ToProductResponse()).ToList();
        }

        public async Task<ProductResponse?> GetProductByProductID(int id)
        {
            Product? product = await _productsRepository.GetProductByProductID(id);
            if (product == null) return null;
            return product.ToProductResponse();
        }

        public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest? productUpdateRequest)
        {
            if (productUpdateRequest == null) return null;

            Product? product = productUpdateRequest.ToProduct();
            product = await _productsRepository.UpdatePerson(product);

            if (product == null) return null;
            return product.ToProductResponse();
        }
    }
}

