using System;
using POS.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Core.DTOs
{
	public class CustomerPurchasePerProductDto
	{
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal AmountPerProduct { get; set; }
    }
}

