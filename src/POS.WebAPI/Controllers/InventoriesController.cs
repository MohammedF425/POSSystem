using System;
using Microsoft.AspNetCore.Mvc;
using POS.Core.DTOs;
using POS.Core.Exceptions;
using POS.Core.ServiceContracts;
using POS.Core.Services;

namespace POS.WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InventoriesController : ControllerBase
	{
		private readonly IInventoriesService _inventoriesService;
		public InventoriesController(IInventoriesService inventoriesService)
		{
			_inventoriesService = inventoriesService;
		}

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryResponse>> GetInventoryByInventoryID(int id)
        {
            try
            {
                InventoryResponse inventoryResponse = await _inventoriesService.GetInventoryByInventoryID(id);
                return Ok(inventoryResponse);
            }
            catch (InventoryDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<InventoryResponse>>> GetAllInventories()
        {
            return Ok(await _inventoriesService.GetAllInventories()); ;
        }

        [HttpPost]
        public async Task<IActionResult> PostInventory(InventoryAddRequest? inventoryAddRequest)
        {
            try
            {
                InventoryResponse? inventoryResponse = await _inventoriesService.AddInventory(inventoryAddRequest);
                return CreatedAtAction(nameof(GetInventoryByInventoryID), new { ID = inventoryResponse.InventoryID }, inventoryResponse);
            }
            catch (ProductDoesNotExistException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{inventoryID}")]
        public async Task<IActionResult> PutInventory(int inventoryID, InventoryUpdateRequest? inventoryUpdateRequest)
        {
            if(inventoryUpdateRequest == null)
            {
                return BadRequest("Must include inventory info");
            }
            try
            {
                await _inventoriesService.UpdateInventory(inventoryUpdateRequest);
                return NoContent();
            }
            catch (ProductDoesNotExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InventoryDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{inventoryID}")]
        public async Task<IActionResult> DeleteInventory(int inventoryID)
        {
            if(await _inventoriesService.DeleteInventoryByInventoryID(inventoryID))
            {
                return NoContent();
            };
            return NotFound();
        }
    }
}
