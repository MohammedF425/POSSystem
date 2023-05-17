using System;
using System.Runtime.Serialization;

namespace POS.Core.Exceptions
{
	public class ReceiptInvalidException : Exception
	{
		public ReceiptInvalidException()
		{
		}

        public ReceiptInvalidException(string? message) : base(message)
        {
        }

        public ReceiptInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

