using System;
namespace POSMaui.Library.Models
{
	public class InventoryModel
	{
		public int InventoryID { get; set; }
		public string InventoryDescription { get; set; }
		public int Units { get; set; }
		public decimal WholesalePricePerInventory { get; set; }
		public int ProductID { get; set; }
		public string ProductDescription{ get; set; }
		public string Barcode { get; set; }
		public decimal WholesalePricePerUnit
		{
			get => WholesalePricePerInventory / Units;
		}
	}
}

