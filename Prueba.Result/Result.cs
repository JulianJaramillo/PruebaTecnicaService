using System;
using System.Runtime.Serialization;

namespace Prueba.Result
{
    [DataContract]
    public sealed class Result<T>
    {
        [DataMember]
        public T Value { get; private set; }
        [DataMember]
        public bool SuccessfulOperation { get; private set; }
        [DataMember]
        public string Message { get; private set; }
        [DataMember]
        public string Exception { get; private set; }
        public System.Exception Error { get; private set; }
        public static Result<T> Success(T resultado, string message)
        {
            return new Result<T>()
            {
                Message = message,
                SuccessfulOperation = true,
                Value = resultado
            };
        }
        public static Result<T> Issue(T result, string message, Exception exception)
        {
            return new Result<T>()
            {
                Message = message,
                SuccessfulOperation = false,
                Value = result,
                Exception = exception.ToString(),
                Error = exception
            };
        }
        public static Result<T> Issue(T result, string message)
        {
            return new Result<T>()
            {
                Message = message,
                SuccessfulOperation = false,
                Value = result,
                Exception = message,
                Error = new PruebaSoftException(message)
            };
        }
    }
}
