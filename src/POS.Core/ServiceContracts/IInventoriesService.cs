using System;
using POS.Core.DTOs;

namespace POS.Core.ServiceContracts
{
	public interface IInventoriesService
	{
        Task<InventoryResponse> AddInventory(InventoryAddRequest inventoryAddRequest);
        Task<List<InventoryResponse>> GetAllInventories();
        Task<InventoryResponse> GetInventoryByInventoryID(int id);
        Task<InventoryResponse> UpdateInventory(InventoryUpdateRequest inventoryUpdateRequest);
        Task<bool> DeleteInventoryByInventoryID(int id);
    }
}

