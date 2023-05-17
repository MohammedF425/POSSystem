using System;
using System.Net.Http.Json;
using POS.Core.DTOs;
using POS.Core.ServiceContracts;

namespace POSMaui.Library.Api
{
    public class InventoryEndpoint : IInventoriesService
    {
        private readonly IAPIHelper _apiHelper;
        private readonly string routeUri = "api/Inventories";

        public InventoryEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<InventoryResponse> AddInventory(InventoryAddRequest inventoryAddRequest)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync<InventoryAddRequest>(routeUri, inventoryAddRequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    var inventory = await response.Content.ReadFromJsonAsync<InventoryResponse>();
                    return inventory;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                };
            }
        }

        public async Task<bool> DeleteInventoryByInventoryID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InventoryResponse>> GetAllInventories()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(routeUri))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<InventoryResponse>>();
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }

            }
        }

        public async Task<InventoryResponse> GetInventoryByInventoryID(int id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"{routeUri}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var inventory = await response.Content.ReadFromJsonAsync<InventoryResponse>();
                    return inventory;
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<InventoryResponse> UpdateInventory(InventoryUpdateRequest inventoryUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}

