using System;
using Microsoft.EntityFrameworkCore;
using POS.Core.Domain.Entities;
using POS.Core.Domain.RepositoryContracts;
using POS.Core.Exceptions;
using POS.Infrastructure.DatabaseContext;

namespace POS.Infrastructure.Repositories
{
	public class ReceiptRepository : IReceiptRepository
	{
        private readonly ApplicationDbContext _dbContext;
		public ReceiptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Receipt> AddReceipt(Receipt receipt)
        {
            _dbContext.Receipts.Add(receipt);
            await _dbContext.SaveChangesAsync();
            return receipt;
        }

        public async Task<bool> DeleteReceiptByReceiptID(int id)
        {
            Receipt? receipt = await _dbContext.Receipts.FirstOrDefaultAsync(temp => temp.ReceiptID == id);
            if(receipt == null)
            {
                return false;
            }

            // Removing every product purchased with a receipt number of id
            var customerPurchases = _dbContext.CustomerPurchasePerProducts.Where(temp => temp.ReceiptID == id);
            _dbContext.CustomerPurchasePerProducts.RemoveRange(customerPurchases);

            // Deleting the receipt
            _dbContext.Receipts.Remove(receipt);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Receipt>> GetAllReceipts()
        {
            return await _dbContext.Receipts.ToListAsync();
        }

        public async Task<Receipt> GetReceiptByReceiptID(int id)
        {
            Receipt? receipt = await _dbContext.Receipts.FirstOrDefaultAsync(temp => temp.ReceiptID == id);
            if(receipt == null)
            {
                throw new ReceiptInvalidException("Receipt number: {id} is invalid");
            }
            return receipt;
        }
    }
}

