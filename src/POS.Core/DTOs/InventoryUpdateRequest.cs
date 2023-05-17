using System;
using POS.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Core.DTOs
{
	public class InventoryUpdateRequest
    {
        public int InventoryID { get; set; }
        public string? Description { get; set; }
        public int Units { get; set; }
        public decimal WholesalePricePerInventory { get; set; }
        public int productID { get; set; }

        public Inventory ToInventory()
        {
            return new Inventory()
            {
                InventoryID = this.InventoryID,
                Description = this.Description,
                Units = this.Units,
                WholesalePricePerInventory = this.WholesalePricePerInventory,
                productID = this.productID
            };
        }
    }

}

