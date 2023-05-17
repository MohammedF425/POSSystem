using System;
using Microsoft.EntityFrameworkCore;
using POS.Core.Domain.Entities;
using POS.Core.Domain.RepositoryContracts;
using POS.Infrastructure.DatabaseContext;

namespace POS.Infrastructure.Repositories
{
	public class CustomerPurchasePerProductRepository: ICustomerPurchasePerProductRepository
	{

        private readonly ApplicationDbContext _dbContext;
        public CustomerPurchasePerProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CustomerPurchasePerProduct> AddPurchasedProduct(CustomerPurchasePerProduct product)
        {
            _dbContext.CustomerPurchasePerProducts.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<CustomerPurchasePerProduct>> GetAllPurchasedProducts()
        {
            return await _dbContext.CustomerPurchasePerProducts.ToListAsync();
        }

        public async Task<List<CustomerPurchasePerProduct>> GetAllPurchasedProductsByReceiptID(int id)
        {
            var products = await _dbContext.CustomerPurchasePerProducts.Where(temp => temp.ReceiptID == id).ToListAsync();
            return products;
        }

        public async Task<CustomerPurchasePerProduct> GetPurchasedProductByID(int id)
        {
            CustomerPurchasePerProduct? product = await _dbContext.CustomerPurchasePerProducts.FirstOrDefaultAsync(temp => temp.CustomerPurchaseID == id);
            if(product == null)
            {
                throw new Exception($"Id: {id} does not exist");

            }
            return product;
        }
    }
}

