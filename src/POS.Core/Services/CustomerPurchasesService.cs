using System;
using POS.Core.Domain.Entities;
using POS.Core.Domain.RepositoryContracts;
using POS.Core.DTOs;
using POS.Core.ServiceContracts;

namespace POS.Core.Services
{
	public class CustomerPurchasesService : ICustomerPurchasesService
	{
        private readonly ICustomerPurchasePerProductRepository _customerPurchasePerProductRepository;
        private readonly IReceiptRepository _receiptRepository;
		public CustomerPurchasesService(ICustomerPurchasePerProductRepository customerPurchasePerProductRepository,
            IReceiptRepository receiptRepository)
		{
            _customerPurchasePerProductRepository = customerPurchasePerProductRepository;
            _receiptRepository = receiptRepository;
		}

        public async Task<CustomerPurchasesResponse> GetReceiptByReceiptID(int receiptID)
        {
            Receipt receipt = await _receiptRepository.GetReceiptByReceiptID(receiptID);

            CustomerPurchasesResponse customerPurchasesResponse = new CustomerPurchasesResponse()
            {
                ReceiptID = receiptID,
                DateTime = receipt.ReceiptDateTime,
                CustomerProductsBought = new List<CustomerPurchasePerProductDto>()
            };

            var products = await _customerPurchasePerProductRepository.GetAllPurchasedProductsByReceiptID(receiptID);
            foreach(var p in products)
            {
                CustomerPurchasePerProductDto dto = new CustomerPurchasePerProductDto()
                {
                    ProductID = p.ProductID,
                    AmountPerProduct = p.AmountPerProduct,
                    Quantity = p.Quantity
                };
                customerPurchasesResponse.CustomerProductsBought.Add(dto);
            }
            return customerPurchasesResponse;
        }

        public async Task<CustomerPurchasesResponse> PostReceipt(CustomerPurchasesRequest customerPurchasesRequest)
        {
            CustomerPurchasesResponse customerPurchasesResponse = new CustomerPurchasesResponse();
            Receipt receipt = new Receipt()
            {
                ReceiptDateTime = DateTime.UtcNow
            };
            // look ........................
            await _receiptRepository.AddReceipt(receipt);

            foreach (var customerProduct in customerPurchasesRequest.CustomerProductsBought)
            {
                var customerPurchasePerProduct = new CustomerPurchasePerProduct()
                {
                    ReceiptID = receipt.ReceiptID,
                    AmountPerProduct = customerProduct.AmountPerProduct,
                    ProductID = customerProduct.ProductID,
                    Quantity = customerProduct.Quantity
                };
                await _customerPurchasePerProductRepository.AddPurchasedProduct(customerPurchasePerProduct);
            }

            CustomerPurchasesResponse purchasesResponse = new CustomerPurchasesResponse()
            {
                DateTime = receipt.ReceiptDateTime,
                ReceiptID = receipt.ReceiptID,
                CustomerProductsBought = customerPurchasesRequest.CustomerProductsBought
            };

            return purchasesResponse;
        }
    }
}

