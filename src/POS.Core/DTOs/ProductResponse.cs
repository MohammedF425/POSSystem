using System;
using POS.Core.Domain.Entities;

namespace POS.Core.DTOs
{
	public class ProductResponse
	{
        public int ID { get; set; }
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
    public static class ProductExtension
    {
        public static ProductResponse? ToProductResponse(this Product product)
        {
            return new ProductResponse()
            {
                ID = product.ID,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Barcode = product.Barcode
            };
        }
    }
}

