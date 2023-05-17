using System;
using POS.Core.DTOs;
using POS.Core.ServiceContracts;
using System.Net.Http.Json;

namespace POSMaui.Library.Api
{
	public class ProductEndpoint : IProductsService
	{
        private readonly IAPIHelper _apiHelper;
        private readonly string routeUri = "api/Products";
		public ProductEndpoint(IAPIHelper apiHelper)
		{
            _apiHelper = apiHelper;
		}

        public async Task<ProductResponse> AddProduct(ProductAddRequest productAddRequest)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync<ProductAddRequest>(routeUri, productAddRequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadFromJsonAsync<ProductResponse>();
                    return product;
                }
                return null;
            }
        }

        public Task<bool> DeleteProductByProductID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(routeUri))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ProductResponse>>();
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                
            }
        }

        public async Task<ProductResponse> GetProductByProductID(int id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"{routeUri}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadFromJsonAsync<ProductResponse>();
                    return product;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<ProductResponse> UpdateProduct(ProductUpdateRequest product)
        {
            throw new NotImplementedException();
        }
    }
}

