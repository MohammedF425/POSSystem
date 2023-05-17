using System;
using POS.Core.Domain.Entities;

namespace POS.Core.DTOs
{
	public class ProductAddRequest
	{
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? Barcode { get; set; }

        public Product ToProduct()
        {
            return new Product()
            {
                ProductDescription = this.ProductDescription,
                Price = this.Price,
                Barcode = this.Barcode
            };
        }
    }

    
}

