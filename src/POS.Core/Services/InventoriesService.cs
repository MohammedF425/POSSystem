using System;
using POS.Core.Domain.Entities;
using POS.Core.Domain.RepositoryContracts;
using POS.Core.DTOs;
using POS.Core.ServiceContracts;
using System.Linq;

namespace POS.Core.Services
{
	public class InventoriesService : IInventoriesService
	{
        private readonly IInventoriesRepository _inventoriesRepository;
		public InventoriesService(IInventoriesRepository inventoriesRepository)
		{
            _inventoriesRepository = inventoriesRepository;
		}

        public async Task<InventoryResponse> AddInventory(InventoryAddRequest inventoryAddRequest)
        {
            Inventory inventory = inventoryAddRequest.ToInventory();
            inventory = await _inventoriesRepository.AddInventory(inventory);
            return inventory.ToInventoryResponse();
        }

        public async Task<bool> DeleteInventoryByInventoryID(int id)
        {
            return await _inventoriesRepository.DeleteInventoryByInventoryID(id);
        }

        public async Task<List<InventoryResponse>> GetAllInventories()
        {
            return (await _inventoriesRepository.GetAllInventory())
                .Select(temp => temp.ToInventoryResponse()).ToList();
        }

        public async Task<InventoryResponse> GetInventoryByInventoryID(int id)
        {
            return (await _inventoriesRepository.GetInventoryByInventoryID(id))
                .ToInventoryResponse();
        }

        public async Task<InventoryResponse> UpdateInventory(InventoryUpdateRequest inventoryUpdateRequest)
        {
            Inventory inventory = inventoryUpdateRequest.ToInventory();
            inventory = await _inventoriesRepository.UpdateInventory(inventory);
            return inventory.ToInventoryResponse();
        }
    }
}

