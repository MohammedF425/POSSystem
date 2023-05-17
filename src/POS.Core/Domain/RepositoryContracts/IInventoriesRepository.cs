using System;
using POS.Core.Domain.Entities;

namespace POS.Core.Domain.RepositoryContracts
{
    public interface IInventoriesRepository
    {
        Task<Inventory> AddInventory(Inventory inventory);
        Task<List<Inventory>> GetAllInventory();
        Task<Inventory> GetInventoryByInventoryID(int id);
        Task<bool> DeleteInventoryByInventoryID(int id);
        Task<Inventory> UpdateInventory(Inventory inventory);
    }
}

