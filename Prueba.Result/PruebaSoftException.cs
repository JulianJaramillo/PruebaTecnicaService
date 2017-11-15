using System;
using System.Runtime.Serialization;

namespace Prueba.Result
{
    public class PruebaSoftException : Exception
    {

        public PruebaSoftException()
        {
        }
        public PruebaSoftException(string message)
            : base(message)
        {
        }
        public PruebaSoftException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected PruebaSoftException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
