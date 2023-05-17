using System;
using POS.Core.Domain.Entities;

namespace POS.Core.Domain.RepositoryContracts
{
	public interface IReceiptRepository
	{
        Task<Receipt> AddReceipt(Receipt receipt);
        Task<List<Receipt>> GetAllReceipts();
        Task<Receipt> GetReceiptByReceiptID(int id);
        Task<bool> DeleteReceiptByReceiptID(int id);   
	}
}

