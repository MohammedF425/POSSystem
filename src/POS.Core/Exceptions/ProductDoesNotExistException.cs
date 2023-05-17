using System;
using System.Runtime.Serialization;

namespace POS.Core.Exceptions
{
	public class ProductDoesNotExistException : Exception
	{
		public ProductDoesNotExistException()
		{
		}

        public ProductDoesNotExistException(string? message) : base(message)
        {
        }
        protected ProductDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

