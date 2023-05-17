using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Core.Domain.Entities
{
	public class Inventory
	{
		[Key]
		public int InventoryID { get; set; }

		[Required(ErrorMessage = "Inventory must have a description")]
		public string? Description { get; set; }

		[Required(ErrorMessage = "Inventory can not be empty")]
		public int Units { get; set; }

		public decimal WholesalePricePerInventory { get; set; }

        [ForeignKey("Product")]
        public int productID { get; set; }

		public Product? Product { get; set; }
    }
}

