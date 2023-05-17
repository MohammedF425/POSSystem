using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using POS.Core.DTOs;
using POS.Core.Exceptions;
using POS.Core.ServiceContracts;
using POS.Core.Services;

namespace POS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerPurchasesController : ControllerBase
    {
        private readonly ICustomerPurchasesService _customerPurchasesService;
        public CustomerPurchasesController(ICustomerPurchasesService customerPurchaseService)
        {
            _customerPurchasesService = customerPurchaseService;
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomerReceipt(CustomerPurchasesRequest customerPurchases)
        {
            try
            {
                CustomerPurchasesResponse? response = await _customerPurchasesService.PostReceipt(customerPurchases);
                if (response == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(GetCustomerReceiptByReceiptID), new { ID = response.ReceiptID }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerPurchasesResponse>> GetCustomerReceiptByReceiptID(int id)
        {
            try
            {
                CustomerPurchasesResponse? response = await _customerPurchasesService.GetReceiptByReceiptID(id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (ReceiptInvalidException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}

