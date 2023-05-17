using System;
using POS.Core.Domain.Entities;
using POS.Core.Domain.RepositoryContracts;
using POS.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using POS.Core.Exceptions;

namespace POS.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            Product? productWithSameBarcode = await _dbContext.Products.FirstOrDefaultAsync(temp => temp.Barcode == product.Barcode);
            if (productWithSameBarcode != null)
            {
                throw new BarcodeExistException("Barcode already exists", product.ProductDescription, product.Price);
            }
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductByProductID(int id)
        {
            _dbContext.RemoveRange(_dbContext.Products.Where(temp => temp.ID == id));
            int rowsDeleted = await _dbContext.SaveChangesAsync();
            return rowsDeleted > 0;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByProductID(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(temp => temp.ID == id);
        }

        public async Task<Product?> UpdatePerson(Product product)
        {
            Product? matchingProduct = await _dbContext.Products.FirstOrDefaultAsync(temp =>temp.ID == product.ID);
            if(matchingProduct == null)
            {
                return null;
            }
            matchingProduct.Price = product.Price;
            matchingProduct.ProductDescription = product.ProductDescription;
            matchingProduct.Barcode = product.Barcode;

            await _dbContext.SaveChangesAsync();

            return matchingProduct;
        }
    }
}

