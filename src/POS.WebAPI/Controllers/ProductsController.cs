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
	public class ProductsController: ControllerBase
	{
		private readonly IProductsService _productsService;

		public ProductsController(IProductsService productsService)
		{
			_productsService = productsService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductResponse>> GetProductByProductID(int id)
		{
			ProductResponse? productResponse = await _productsService.GetProductByProductID(id);
			if (productResponse == null)
			{
				return NotFound();
			}
			return Ok(productResponse);
		}

		[HttpGet]
		public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
		{
			return Ok(await _productsService.GetAllProducts());
		}

		[HttpPost]
		public async Task<IActionResult> PostProduct(ProductAddRequest? productAddRequest)
		{
			try
			{
                ProductResponse? postResponse = await _productsService.AddProduct(productAddRequest);
                if (postResponse == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(GetProductByProductID), new { ID = postResponse.ID }, postResponse);
            }
			catch(BarcodeExistException ex)
			{
				return BadRequest(ex.Message + ": " + ex.ProductDescription + "-" + ex.Price.ToString("C"));
			}

		}

		[HttpPut("{productID}")]
		public async Task<IActionResult> PutProduct(int productID, ProductUpdateRequest? productUpdateRequest)
		{
			if (productUpdateRequest == null || productUpdateRequest.ID != productID) return BadRequest();
			

			ProductResponse? productResponse = await _productsService.UpdateProduct(productUpdateRequest);
			if(productResponse == null)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{productID}")]
		public async Task<IActionResult> DeleteProduct(int productID)
		{
			if(await _productsService.DeleteProductByProductID(productID))
			{
				return NoContent();
			}
			return NotFound();
		}
	}
}

