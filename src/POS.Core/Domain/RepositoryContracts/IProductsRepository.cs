using System;
using POS.Core.Domain.Entities;

namespace POS.Core.Domain.RepositoryContracts
{
	public interface IProductsRepository
	{
		Task<Product> AddProduct(Product product);
		Task<List<Product>> GetAllProducts();
		Task<Product?> GetProductByProductID(int id);
		Task<bool> DeleteProductByProductID(int id);
		Task<Product> UpdatePerson(Product product);
	}
}

