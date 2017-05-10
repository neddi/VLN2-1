using System;
using System.Runtime.Serialization;

namespace ErroProject.Custom
{
	public class CustomApplicationException : Exception
    {
        public CustomApplicationException()
        {
        }

        public CustomApplicationException(string message) : base(message)
        {
        }

        public CustomApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}