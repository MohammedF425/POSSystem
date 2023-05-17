using System;
using POS.Core.Domain.Entities;

namespace POS.Core.Domain.RepositoryContracts
{
	public interface ICustomerPurchasePerProductRepository
	{
        Task<CustomerPurchasePerProduct> AddPurchasedProduct(CustomerPurchasePerProduct product);
        Task<List<CustomerPurchasePerProduct>> GetAllPurchasedProducts();
        Task<CustomerPurchasePerProduct> GetPurchasedProductByID(int id);
        Task<List<CustomerPurchasePerProduct>> GetAllPurchasedProductsByReceiptID(int id);
    }
}

