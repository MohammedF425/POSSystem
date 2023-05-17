using System;
using POS.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Core.DTOs
{
	public class InventoryResponse
	{
        public int InventoryID { get; set; }
        public string? Description { get; set; }
        public int Units { get; set; }
        public decimal WholesalePricePerInventory { get; set; }
        public int productID { get; set; }
    }
    public static class InventoryExtension
    {
        public static InventoryResponse ToInventoryResponse(this Inventory inventory)
        {
            return new InventoryResponse()
            {
                InventoryID = inventory.InventoryID,
                Description = inventory.Description,
                Units = inventory.Units,
                WholesalePricePerInventory = inventory.WholesalePricePerInventory,
                productID = inventory.productID
            };
        }
    }
}

