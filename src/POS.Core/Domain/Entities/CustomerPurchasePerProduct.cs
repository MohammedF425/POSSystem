using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Core.Domain.Entities
{
	public class CustomerPurchasePerProduct
	{
		[Key]
		public int CustomerPurchaseID { get; set; }

		[Required(ErrorMessage = "Reciept number not specified")]
		[ForeignKey("Receipt")]
		public int ReceiptID { get; set; }

		[Required(ErrorMessage = "Product ID not specified")]
		[ForeignKey("Product")]
		public int ProductID { get; set; }

		[Range(1, 1000)]
        public int Quantity { get; set; }

		public decimal AmountPerProduct { get; set; }

        public Product? Product { get; set; }
		public Receipt? Receipt { get; set; }


	}
}

