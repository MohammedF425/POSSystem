using System;
using System.ComponentModel.DataAnnotations;

namespace POS.Core.Domain.Entities
{
	public class Receipt
	{
		public int ReceiptID { get; set; }

		[Required(ErrorMessage="Date and time of receipt must be available")]
		public DateTime ReceiptDateTime { get; set; }

		public ICollection<CustomerPurchasePerProduct>? CustomerPurchasePerProducts { get; set; }
	}
}

