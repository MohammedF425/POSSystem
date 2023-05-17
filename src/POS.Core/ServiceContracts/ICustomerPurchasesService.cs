using System;
using POS.Core.DTOs;

namespace POS.Core.ServiceContracts
{
	public interface ICustomerPurchasesService
	{
		Task<CustomerPurchasesResponse> PostReceipt(CustomerPurchasesRequest customerPurchasesRequest);
		Task<CustomerPurchasesResponse> GetReceiptByReceiptID(int receiptID);
	}
}

