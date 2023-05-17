using System;
using System.Runtime.Serialization;

namespace POS.Core.Exceptions
{
    public class InventoryDoesNotExistException : Exception
    {
        public InventoryDoesNotExistException()
        {
        }

        public InventoryDoesNotExistException(string? message) : base(message)
        {
        }

        public InventoryDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

