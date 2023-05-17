using System;
namespace POS.Core.DTOs
{
	public class CustomerPurchasesRequest
	{
		public List<CustomerPurchasePerProductDto> CustomerProductsBought { get; set; }
		
	}
}

