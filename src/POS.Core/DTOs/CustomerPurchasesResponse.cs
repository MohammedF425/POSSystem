using System;
namespace POS.Core.DTOs
{
	public class CustomerPurchasesResponse
	{
		public int ReceiptID { get; set; }
		public DateTime DateTime { get; set; }
        public List<CustomerPurchasePerProductDto> CustomerProductsBought { get; set; }
    }
}

