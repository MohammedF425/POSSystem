using System;
using System.ComponentModel.DataAnnotations;

namespace POS.Core.Domain.Entities
{
	public class Product
	{
        [Key]
        public int ID { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? Barcode { get; set; }

        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<CustomerPurchasePerProduct>? CustomerPurchasesPerProducts { get; set; }
    }
}

