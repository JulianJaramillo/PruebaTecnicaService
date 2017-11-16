using System;
using System.Runtime.Serialization;

namespace Prueba.Result
{
    public class PruebaSoftException : Exception
    {
        // Construccion de cuerpo de mensaje para tener mas informacion de la respuesta del servicio, por si se presenta algun problema
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
