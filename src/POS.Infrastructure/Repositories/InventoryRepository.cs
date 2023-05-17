using System;
using Microsoft.EntityFrameworkCore;
using POS.Core.Domain.Entities;
using POS.Core.Domain.RepositoryContracts;
using POS.Core.Exceptions;
using POS.Infrastructure.DatabaseContext;

namespace POS.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoriesRepository
    {
        private readonly ApplicationDbContext db;
        public InventoryRepository(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            Product? product = await db.Products.FirstOrDefaultAsync(temp => temp.ID == inventory.productID);
            if(product == null)
            {
                throw new ProductDoesNotExistException("Product does not exist. Add product then try again");
            }
            db.Inventories.Add(inventory);
            await db.SaveChangesAsync();
            return inventory;
        }

        public async Task<bool> DeleteInventoryByInventoryID(int id)
        {
            Inventory inventory = await db.Inventories.FirstAsync(temp => temp.InventoryID == id);
            if(inventory == null)
            {
                return false;
            }
            db.Inventories.Remove(inventory);
            return await db.SaveChangesAsync() > 0;

        }


        public async Task<List<Inventory>> GetAllInventory()
        {
            return await db.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryByInventoryID(int id)
        {
            Inventory? inventory = await db.Inventories.FirstOrDefaultAsync(temp => temp.InventoryID == id);
            if(inventory == null)
            {
                throw new InventoryDoesNotExistException($"Inventory with id number of {id} does not exist");
            }
            return inventory;
        }

        public async Task<Inventory> UpdateInventory(Inventory inventory)
        {
            Inventory match = await GetInventoryByInventoryID(inventory.InventoryID);
            match.productID = inventory.productID;
            match.Description = inventory.Description;
            match.Units = inventory.Units;
            match.WholesalePricePerInventory = inventory.WholesalePricePerInventory;

            await db.SaveChangesAsync();
            return match;
            
        }
    }
}

