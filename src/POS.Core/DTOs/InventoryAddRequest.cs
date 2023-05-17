using System;
using POS.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Core.DTOs
{
	public class InventoryAddRequest
	{
        public string? Description { get; set; }
        public int Units { get; set; }
        public decimal WholesalePricePerInventory { get; set; }
        public int productID { get; set; }

        public Inventory ToInventory()
        {
            return new Inventory()
            {
                productID = this.productID,
                Description = this.Description,
                Units = this.Units,
                WholesalePricePerInventory = this.WholesalePricePerInventory
            };
        }
    }
}

