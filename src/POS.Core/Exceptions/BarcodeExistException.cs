using System;
using System.Runtime.Serialization;

namespace POS.Core.Exceptions
{
    public class BarcodeExistException : Exception
    {
        public string? ProductDescription { get; }
        public decimal Price { get; }
        public BarcodeExistException()
        {
        }

        public BarcodeExistException(string? message) : base(message)
        {
        }

        public BarcodeExistException(string? message, string? productDescription, decimal price) : base(message)
        {
            ProductDescription = productDescription;
            Price = price;
        }

        public BarcodeExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}

